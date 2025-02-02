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
<<<<<<< HEAD
using MySqlConnector;
using System.IO.Enumeration;
=======

>>>>>>> main

enum client_type{
    ATM,
    NETWORK
}

class ClientConnections{
<<<<<<< HEAD
    public static async Task Main(){
        ClientConnections Visa = new ClientConnections("Visa", client_type.NETWORK);
        
        ClientConnections MC = new ClientConnections("Mastercard", client_type.NETWORK);
        var visaTask = Visa.ClientConnect("");
        var mcTask = MC.ClientConnect("");

        await Task.WhenAll(visaTask, mcTask);

        while(true){
            await Task.Delay(1000);
        }
        
    }
    //decleration and constructor
    private string client_name;
    private TcpClient client;
    private NetworkStream stream;
    private client_type type;
    private Timer keepAliveTimer;
    private bool isConnected = false;

    DatabaseConnector db = new DatabaseConnector();

=======
    public static void Main(){
        testingFuncs test = new();
        test.clientTests();
    }
    //decleration and constructor
    private string client_name;
    public clientAcc client_acc;
    private TcpClient client;
    private NetworkStream stream;
    private client_type type;
>>>>>>> main

    public string getName(){
        return this.client_name;
    }
    
    public void setName(string name){
        this.client_name = name;
    }
    
<<<<<<< HEAD
    public ClientConnections(string client_name, client_type type){
        this.client_name = client_name;

=======
    public ClientConnections(string client_name, clientAcc client_acc, client_type type){
        this.client_name = client_name;
        this.client_acc = client_acc;
>>>>>>> main
        this.type = type;
        
    }
    //class methods GENERAL FUNCTIONS
<<<<<<< HEAD
    public async Task<TcpClient> ClientConnect(string server){
        try{
            db.ConnectToDatabase();
            int port = 6667;
            client = new TcpClient();
            await client.ConnectAsync("127.0.0.1", port);
            stream = client.GetStream();
            Console.WriteLine($"[Client] Connected to server {server}:{port}");
            keepAliveTimer = new Timer(SendKeepAlive, null, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(5));

            _ = Task.Run(() => handleServerData());
=======
    public TcpClient clientConnect(String server){
        try{
            Int32 port = 6667;
            this.client = new TcpClient("127.0.0.1", port);
            this.stream = client.GetStream();
            Console.WriteLine("[Client] Connected to server");
            handleServerData();
>>>>>>> main
            return client;
        }
        catch(Exception e){
            Console.WriteLine("[Client] Unable to connect:", e.Message);
            return null;
        }
    }

<<<<<<< HEAD
    private void SendKeepAlive(object state)
{
    if (isConnected && client?.Connected == true)
    {
        try
        {
            byte[] keepAliveMsg = Encoding.UTF8.GetBytes("KeepAlive");
            stream?.Write(keepAliveMsg, 0, keepAliveMsg.Length);
        }
        catch (Exception e)
        {
            Console.WriteLine($"[Client] Keep-alive failed: {e.Message}");
            isConnected = false;
        }
    }
}

    private async Task handleServerData(){
=======
    private void handleServerData(){
>>>>>>> main
        int i;
        string data = null;
        byte[] buffer = new byte[256];
        try{
            while((i = stream.Read(buffer, 0, buffer.Length)) != 0){
                string json = Encoding.UTF8.GetString(buffer, 0, i);
<<<<<<< HEAD
                if(json.Contains("<|EOM|>")){
                    int index = json.IndexOf("<|EOM|>");
                    json = json.Substring(0, index);
                }
                else{
                    Console.WriteLine("EOM not found");
                }
                Console.WriteLine("Data received");
                
=======
                Console.WriteLine("Data received");
>>>>>>> main
                if(i > 0){
                    Console.WriteLine("Received: {0}", json);
                    Request request = null;
                    try{
                        request = JsonConvert.DeserializeObject<Request>(json);
                    }
                    catch(Exception e){
                        Console.WriteLine("Error: " + e.Message);

                    }
                    if(request != null){
<<<<<<< HEAD
                        _ = Task.Run(() => handle_request(request));
=======
                        handle_request(request);
                        Request test = new Request("BalanceEnq", "123456789", "1234", "Visa", "100", false);
                        send_request(test, stream);

>>>>>>> main
                    }
                    else{
                        Console.WriteLine("Request is null");
                    }
                }
                
            }
        }
        catch(Exception e){
            Console.WriteLine("[Client] Unable to read data from server: " + e.Message);
<<<<<<< HEAD
            this.ClientConnect("");
=======
            this.clientConnect("");
>>>>>>> main
        }
    }
    public TcpClient GetTcpClient(){
        return client;
    }
    //class methods ATM FUNCTIONS
<<<<<<< HEAD
     
    //class methods NETWORK FUNCTIONS
=======
     //class methods NETWORK FUNCTIONS
>>>>>>> main
    public void handle_request(Request request){
        Request response = new Request();
        if(request.type == "Hello"){
            Console.WriteLine("[Client] Hello message received");
<<<<<<< HEAD
            response.type = "Hello.NETWORK";
            response.network = this.client_name;
            send_request(response, stream);
        }
        else if(request.type == "BalanceEnq"){
            Console.WriteLine("[Client] Balance request received");
            response.type = "BalanceEnq.RESPONSE";
            response.card_number = request.card_number;
            response.pin = request.pin;
            response.network = request.network;
            response.amount = getBalance(request.card_number, request.network).ToString();
            send_request(response, stream);
        }
        else if(request.type == "Withdrawl"){
            response.card_number = request.card_number;
            response.pin = request.pin;
            response.network = request.network;
            Console.WriteLine("[Client] Withdrawl request received");
            if(withdrawl(request.card_number, request.network, int.Parse(request.amount))){
                response.type = "Withdrawl.APPROVED";
                
            }
            else{
                response.type = "Withdrawl.DECLINED";
            }
            send_request(response, stream);
        }
        else{
            Console.WriteLine("[Client] Request type not recognized");
        }
    }
    private void send_request(Request request, Stream stream){
        Console.WriteLine("[Client] Sending request");
        string jsonString = JsonConvert.SerializeObject(request);
        logging(request);
        jsonString += "<|EOM|>";
=======
            response.type = "Hello.nitwork";
            response.network = "Visa";
            send_request(response, stream);
        }
        if(request.type == "BalanceEnq"){
            Console.WriteLine("[Client] Balance request received");
            response.type = "BalanceEnq";
            response.card_number = request.card_number;
            response.pin = request.pin;
            response.amount = getBalance(request.card_number, request.pin).ToString();
            send_request(response, stream);
        }
    }
    public static void send_request(Request request, Stream stream){
        Console.WriteLine("[Client] Sending request");
        string jsonString = JsonConvert.SerializeObject(request);
>>>>>>> main
        byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonString);
        stream.Write(jsonBytes, 0, jsonBytes.Length);
    }

<<<<<<< HEAD
    private void logging(Request request){
        Console.WriteLine("Logging request");
        string log = $"{DateAndTime.Now}: Request Type: {request.type} Card Number: {request.card_number} Network: {request.network} Amount: {request.amount} \n";
        string filename = "log.txt";
        File.AppendAllText(filename, log);

    }

    //will be made properly when connected to data base
    private int getBalance(string card_number, string net){
        int balance = -1;
        MySqlConnection connection = db.GetConnection();
        if (connection == null || connection.State != System.Data.ConnectionState.Open)
        {
            Console.WriteLine("Database connection is not open.");
            return -1;
        }

        string tableName = net.ToLower() == "visa" ? "VisaCards" : net.ToLower() == "mastercard" ? "MasterCards" : null;

        if (tableName == null)
        {
            Console.WriteLine("Invalid network for card {0}", card_number);

            return -1;
        }
        string query = $"SELECT AccountBalance FROM {tableName} WHERE CardNumber";

        try{
            using (MySqlCommand cmd = new MySqlCommand(query, connection)){
                cmd.Parameters.AddWithValue("@CardNumber", card_number);
                object result = cmd.ExecuteScalar();
                if (result != null){
                    balance = Convert.ToInt32(result);
                }
                else{
                    Console.WriteLine("Invalid card number or PIN.");
                }
            }
        }
        catch (Exception ex){
            Console.WriteLine($"Error retrieving balance: {ex.Message}");
            }

        return balance;
    }

    private bool withdrawl(string card_number, string net, int amountToWithdraw){
        
        // Step 1: Validate the withdrawal request
        if (amountToWithdraw <= 0)
        {
            Console.WriteLine("[Client] Invalid withdrawal amount.");
            return false;  // Invalid amount
        }
        else if(amountToWithdraw > 1000){
            Console.WriteLine("[Client] Large payment detected. Manual approval needed.");
            if(!manual_approval(new Request("Withdrawl", card_number, "", net, amountToWithdraw.ToString(), false))){
                return false;
            }
        }

        // Step 2: Get the current balance
        int currentBalance = getBalance(card_number, net);

        // Step 3: Check if balance is sufficient
        if (currentBalance < amountToWithdraw)
        {
            Console.WriteLine("[Client] Insufficient balance.");
            return false;  // Insufficient funds
        }
        // Step 4: Update the balance by deducting the withdrawal amount
        // Get an active connection from DatabaseConnector
        MySqlConnection connection = db.GetConnection();

        if (connection == null || connection.State != System.Data.ConnectionState.Open)
        {
            Console.WriteLine("Database connection is not open.");
            return false;  // Database connection error
        }
        
        string tableName = net.ToLower() == "visa" ? "VisaCards" : net.ToLower() == "mastercards" ? "MasterCards" : null;

        if (tableName == null)
        {
            Console.WriteLine("Invalid network.");
            return false;
        }

        string query = $"UPDATE {tableName} SET AccountBalance = AccountBalance - @Amount WHERE CardNumber = @CardNumber";
        try{
            using(MySqlCommand cmd = new MySqlCommand(query, connection)){
                cmd.Parameters.AddWithValue("@Amount", amountToWithdraw);
                cmd.Parameters.AddWithValue("@CardNumber", card_number);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0){
                    Console.WriteLine("[Client] Withdrawal successful.");
                    return true;
                }
                else{
                    Console.WriteLine("[Client] Withdrawal failed.");
                    return false;
                }
            }
        }
        catch (Exception ex){
            Console.WriteLine($"Error updating balance: {ex.Message}");
            return false;
        }

    }
    private bool manual_approval(Request request){
        Console.WriteLine("Manual approval required, approve? (Y/N)");
        string response = Console.ReadLine();
        if(response == "Y"){
            return true;
        }
        else{
            return false;
        }

    }

    // private bool verifyPin(string card_number, string pin){
    //     Console.WriteLine("Card Number: " + card_number + " Pin: " + pin);
    //     Console.WriteLine("Client Card Number: " + this.client_acc.card_number + " Client Pin: " + this.client_acc.pin);
    //     if(pin == this.client_acc.pin && card_number == this.client_acc.card_number){
    //         Console.WriteLine("Pin Verified");
    //         return true;
    //     }
    //     else{
    //         Console.WriteLine("Pin not verified");
    //         return false;
    //     }
    // }
}


=======
    //will be made properly when connected to data base
    private int getBalance(string card_number, string pin){
        if(verifyPin(card_number, pin)){
            Console.WriteLine("Balance: " + this.client_acc.balance);
            return this.client_acc.balance;
        }
        else{
            return -1;
        }
    }

    private bool handleTransaction(string card_number, string amount){
        string test_card = "123456789";
        int balance = 1000;
        int intAmount = Int32.Parse(amount);
        if(card_number == test_card){
            if(balance - intAmount >= 0){
                balance -= intAmount;
                return true;
            }
            else{
                return false;
            }
        }
        else{
            return false;
        }
    }
    private bool verifyPin(string card_number, string pin){
        Console.WriteLine("Card Number: " + card_number + " Pin: " + pin);
        Console.WriteLine("Client Card Number: " + this.client_acc.card_number + " Client Pin: " + this.client_acc.pin);
        if(pin == this.client_acc.pin && card_number == this.client_acc.card_number){
            Console.WriteLine("Pin Verified");
            return true;
        }
        else{
            Console.WriteLine("Pin not verified");
            return false;
        }
    }
}

class clientAcc{
    public string card_number;
    public string network;
    public string pin;

    public int balance;

    public clientAcc(string card_number, string network, string pin, int balance){
        this.card_number = card_number;
        this.network = network;
        this.pin = pin;
        this.balance = balance;
    }
}
>>>>>>> main


//testing out visa and MC clients
class testingFuncs{
<<<<<<< HEAD
    // public void clientTests(){
    //     clientAcc test_acc = new("123456789", "Visa", "1234", 1000);
    //     ClientConnections test = new("Visa", test_acc, client_type.NETWORK);
    //     test.clientConnect("127.0.0.1");
    //     if(test.GetTcpClient() != null && test.GetTcpClient().Connected){
    //         while(true){
    //             Console.WriteLine("Running");
    //             Thread.Sleep(100000000);
    //         }
    //     }
    //     else{
    //         Console.WriteLine("Client not connected");
    //     }
    // }
=======
    public void clientTests(){
        clientAcc test_acc = new("123456789", "Visa", "1234", 1000);
        ClientConnections test = new("Visa", test_acc, client_type.NETWORK);
        test.clientConnect("127.0.0.1");
        if(test.GetTcpClient() != null){
            while(true){
                Console.WriteLine("Running");
                Thread.Sleep(1000);
            }
        }
        else{
            Console.WriteLine("Client not connected");
        }
    }

    

//testing out ATM clients
    public void atmTests(){
        clientAcc test_acc = new("1234567890", "Visa", "1234", 1000);
        ClientConnections test = new("Visa", test_acc, client_type.ATM);
        test.setName(test_acc.card_number + "," + test_acc.network + ","+ test_acc.pin); 
        test.clientConnect("127.0.0.1");
        if(test.GetTcpClient() != null){
            while(true){
                Console.WriteLine("Running");
                Thread.Sleep(100000000);
            }
        }
        else{
            Console.WriteLine("Client not connected");
        }

    }
>>>>>>> main
}

class Request{
    public string type;
    public string card_number;
    public string pin;
    public string network;
    public string amount;
    public bool response;

    public Request(string type, string card_number, string pin, string network, string amount, bool response){
        this.type = type;
        this.card_number = card_number;
        this.pin = pin;
        this.network = network;
        this.amount = amount;
        this.response = response;
    }

    public Request(){
        this.type = "";
        this.card_number = "";
        this.pin = "";
        this.network = "";
        this.amount = "";
        this.response = false;
    }

}
<<<<<<< HEAD

class DatabaseConnector
{
    private MySqlConnection connection;

    // Function to connect to the database
    public MySqlConnection ConnectToDatabase()
    {
        string connectionString = "Server=localhost; Database=agiledatabase; Uid=root;";

        try
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Connection to the database was successful!");
            return connection;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Database connection failed: {ex.Message}");
            return null;
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

=======
>>>>>>> main
