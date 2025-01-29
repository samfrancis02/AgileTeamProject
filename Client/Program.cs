using System;
using System.ComponentModel.Design;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Microsoft.VisualBasic;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json;
using System.Data.SqlClient;
using MySqlConnector;
using System.Security.Cryptography;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Net.NetworkInformation;


enum client_type
{
    ATM,
    NETWORK
}

class ClientConnections
{
    public static void Main()
    {
        DatabaseConnector database = new();
        database.ConnectToDatabase();
        testingFuncs test = new(database);
        test.clientTests();
        database.DisconnectFromDatabase();
    }
    //decleration and constructor
    private string client_name;
    public clientAcc client_acc;
    private TcpClient client;
    private NetworkStream stream;
    private client_type type;
    private DatabaseConnector dbConnector;

    public string getName()
    {
        return this.client_name;
    }

    public void setName(string name)
    {
        this.client_name = name;
    }

    public ClientConnections(string client_name, clientAcc client_acc, client_type type, DatabaseConnector dbConnector)
    {
        this.client_name = client_name;
        this.client_acc = client_acc;
        this.type = type;
        this.dbConnector = dbConnector; // Store the database connection
    }
    //class methods GENERAL FUNCTIONS
    public TcpClient clientConnect(String server)
    {
        try
        {
            Int32 port = 6667;
            this.client = new TcpClient("127.0.0.1", port);
            this.stream = client.GetStream();
            Console.WriteLine("[Client] Connected to server");
            handleServerData();
            return client;
        }
        catch (Exception e)
        {
            Console.WriteLine("[Client] Unable to connect:", e.Message);
            return null;
        }
    }

    private void handleServerData()
    {
        int i;
        string data = null;
        byte[] buffer = new byte[256];
        try
        {
            while ((i = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string json = Encoding.UTF8.GetString(buffer, 0, i);
                if (json.Contains("<|EOM|>"))
                {
                    int index = json.IndexOf("<|EOM|>");
                    json = json.Substring(0, index);
                }
                else
                {
                    Console.WriteLine("EOM not found");
                }
                Console.WriteLine("Data received");

                if (i > 0)
                {
                    Console.WriteLine("Received: {0}", json);
                    Request request = null;
                    try
                    {
                        request = JsonConvert.DeserializeObject<Request>(json);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: " + e.Message);

                    }
                    if (request != null)
                    {
                        handle_request(request);
                    }
                    else
                    {
                        Console.WriteLine("Request is null");
                    }
                }

            }
        }
        catch (Exception e)
        {
            Console.WriteLine("[Client] Unable to read data from server: " + e.Message);
            this.clientConnect("");
        }
    }
    public TcpClient GetTcpClient()
    {
        return client;
    }
    //class methods ATM FUNCTIONS

    //class methods NETWORK FUNCTIONS
    public void handle_request(Request request)
    {
        Request response = new Request();
        if (request.type == "Hello")
        {
            Console.WriteLine("[Client] Hello message received");
            response.type = "Hello.NETWORK";
            response.network = "Visa";
            send_request(response, stream);
        }
        else if (request.type == "BalanceEnq")
        {
            Console.WriteLine("[Client] Balance request received");
            response.type = "BalanceEnq.RESPONSE";
            response.card_number = request.card_number;
            response.pin = request.pin;
            response.network = request.network;
            response.amount = getBalance(request.card_number, request.pin, request.network).ToString();
            send_request(response, stream);
        }
        else if (request.type == "Withdrawl")
        {
            Console.WriteLine("[Client] Withdrawl request received");

            int amountToWithdraw = int.TryParse(request.amount, out var amount) ? amount : 0;

            bool withdrawalSuccessful = withdrawAmount(request.card_number, request.pin, request.network, amountToWithdraw);

            // Send response based on whether the withdrawal was successful
            response.type = "Withdrawl.RESPONSE";
            response.card_number = request.card_number;
            response.pin = request.pin;
            response.network = request.network;
            response.amount = amountToWithdraw.ToString();
            response.response = withdrawalSuccessful;

            send_request(response, stream);
        }
        else
        {
            Console.WriteLine("[Client] Request type not recognized");
        }
    }
    public bool withdrawAmount(string card_number, string pin, string net, int amountToWithdraw)
    {
        // Step 1: Validate the withdrawal request
        if (amountToWithdraw <= 0)
        {
            Console.WriteLine("[Client] Invalid withdrawal amount.");
            return false;  // Invalid amount
        }

        // Step 2: Get the current balance
        int currentBalance = getBalance(card_number, pin, net);

        // Step 3: Check if balance is sufficient
        if (currentBalance < amountToWithdraw)
        {
            Console.WriteLine("[Client] Insufficient balance.");
            return false;  // Insufficient funds
        }

        // Step 4: Update the balance by deducting the withdrawal amount
        // Get an active connection from DatabaseConnector
        MySqlConnection connection = dbConnector.GetConnection();

        if (connection == null || connection.State != System.Data.ConnectionState.Open)
        {
            Console.WriteLine("Database connection is not open.");
            return false;  // Database connection error
        }

        // Determine the correct table name securely
        string tableName = net.ToLower() == "visa" ? "VisaCards" : net.ToLower() == "mastercards" ? "MasterCards" : null;

        if (tableName == null)
        {
            Console.WriteLine("Invalid network type.");
            return false;  // Invalid network type
        }

        string hashedPin = HashPin(pin);

        string query = $"UPDATE {tableName} SET AccountBalance = AccountBalance - @Amount WHERE CardNumber = @CardNumber AND HashedPIN = @HashedPIN AND AccountBalance >= @Amount";

        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CardNumber", card_number);
                cmd.Parameters.AddWithValue("@HashedPIN", hashedPin);
                cmd.Parameters.AddWithValue("@Amount", amountToWithdraw);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("[Client] Withdrawal successful.");
                    return true;  // Withdrawal successful
                }
                else
                {
                    Console.WriteLine("[Client] Withdrawal failed (either invalid card/pin or insufficient funds).");
                    return false;  // Withdrawal failed
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing withdrawal: {ex.Message}");
            return false;  // Error in database operation
        }
    }

    public int getBalance(string card_number, string pin, string net)
    {
        int balance = -1; // Default to -1 if credentials are invalid

        // Get an active connection from DatabaseConnector
        MySqlConnection connection = dbConnector.GetConnection();

        if (connection == null || connection.State != System.Data.ConnectionState.Open)
        {
            Console.WriteLine("Database connection is not open.");
            return -1;
        }

        // Determine the correct table name securely
        string tableName = net.ToLower() == "visa" ? "VisaCards" : net.ToLower() == "mastercard" ? "MasterCards" : null;

        if (tableName == null)
        {
            Console.WriteLine("Invalid network type.");
            return -1;
        }
        string hashedPin = HashPin(pin);


        string query = $"SELECT AccountBalance FROM {tableName} WHERE CardNumber = @CardNumber AND HashedPIN = @HashedPIN";

        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CardNumber", card_number);
                cmd.Parameters.AddWithValue("@HashedPIN", hashedPin);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    balance = Convert.ToInt32(result);
                }
                else
                {
                    Console.WriteLine("Invalid card number or PIN.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving balance: {ex.Message}");
        }

        return balance;
    }

    private static string HashPin(string pin)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pin));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower(); // Convert to hex string
        }
    }


    public static void send_request(Request request, Stream stream)
    {
        Console.WriteLine("[Client] Sending request");
        string jsonString = JsonConvert.SerializeObject(request);
        jsonString += "<|EOM|>";
        byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonString);
        stream.Write(jsonBytes, 0, jsonBytes.Length);
    }

    private bool verifyPin(string card_number, string pin)
    {
        Console.WriteLine("Card Number: " + card_number + " Pin: " + pin);
        Console.WriteLine("Client Card Number: " + this.client_acc.card_number + " Client Pin: " + this.client_acc.pin);
        if (pin == this.client_acc.pin && card_number == this.client_acc.card_number)
        {
            Console.WriteLine("Pin Verified");
            return true;
        }
        else
        {
            Console.WriteLine("Pin not verified");
            return false;
        }
    }
}

class clientAcc
{
    public string card_number;
    public string network;
    public string pin;

    public int balance;

    public clientAcc(string card_number, string network, string pin, int balance)
    {
        this.card_number = card_number;
        this.network = network;
        this.pin = pin;
        this.balance = balance;
    }
}


//testing out visa and MC clients
class testingFuncs
{
    private DatabaseConnector dbConnector;

    public testingFuncs(DatabaseConnector dbConnector)
    {
        this.dbConnector = dbConnector;
    }

    public void clientTests()
    {
        clientAcc test_acc = new("5105105105105100", "mastercards", "1234", 1000);
        ClientConnections test = new("mastercards", test_acc, client_type.NETWORK, dbConnector);
        test.clientConnect("127.0.0.1");
        if (test.GetTcpClient() != null && test.GetTcpClient().Connected)
        {
            test.getBalance(test_acc.card_number, test_acc.pin, "mastercards");
            //while (true)
            //{
            //    Console.WriteLine("Running");
            //    Thread.Sleep(100000000);
            //}
        }
        else
        {
            Console.WriteLine("Client not connected");
        }
    }

    public void atmTests()
    {
        clientAcc test_acc = new("5105105105105100", "mastercards", "1234", 1000);
        ClientConnections test = new("Visa", test_acc, client_type.ATM, dbConnector);
        test.setName(test_acc.card_number + "," + test_acc.network + "," + test_acc.pin);
        test.clientConnect("127.0.0.1");

        if (test.GetTcpClient() != null && test.GetTcpClient().Connected)
        {
            while (true)
            {
                Console.WriteLine("Running");
                Thread.Sleep(100000000);
            }
        }
        else
        {
            Console.WriteLine("Client not connected");
        }
    }
}
class DatabaseConnector
{
    public MySqlConnection connection;

    // Function to connect to the database
    public void ConnectToDatabase()
    {
        string connectionString = "Server=localhost; Database=agiledatabase; Uid=root;";

        try
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Connection to the database was successful!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Database connection failed: {ex.Message}");
        }
    }

    // Function to disconnect from the database
    public void DisconnectFromDatabase()
    {
        try
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                Console.WriteLine("Connection closed.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to close the connection: {ex.Message}");
        }
    }

    // Get the connection for performing operations in between
    public MySqlConnection GetConnection()
    {
        return connection;
    }
}


class Request
{
    public string type;
    public string card_number;
    public string pin;
    public string network;
    public string amount;
    public bool response;

    public Request(string type, string card_number, string pin, string network, string amount, bool response)
    {
        this.type = type;
        this.card_number = card_number;
        this.pin = pin;
        this.network = network;
        this.amount = amount;
        this.response = response;
    }

    public Request()
    {
        this.type = "";
        this.card_number = "";
        this.pin = "";
        this.network = "";
        this.amount = "";
        this.response = false;
    }

}
