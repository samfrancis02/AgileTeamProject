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
using System.Data.SqlClient; //Dependency!!

enum client_type{
    ATM,
    NETWORK
}

class ClientConnections{
    public ClientConnections(string network, string cardNumber, string pin) {
    this.network = network;
    this.card_number = cardNumber;
    this.pin = pin;
}
    public static void Main(){
        stressTestConnections();
        // ClientConnections client = new ClientConnections("Visa", "4111111111111111", "1234");
        // client.clientConnect();
    }
    //decleration and constructor
    private string client_name;
    private string card_number;
    private string pin;
    private string network;
    private TcpClient client;
    private NetworkStream stream;

    public string getName(){
        return this.client_name;
    }
    
    public void setName(string name){
        this.client_name = name;
    }
    

    //class methods GENERAL FUNCTIONS
    public void clientConnect(){
        try{
            Int32 port = 6667;
            client = new TcpClient("127.0.0.1", port);
            stream = client.GetStream();
            Console.WriteLine("[Client] Connected to server");
            Thread requestThread = new Thread(sendRandomRequest);
            requestThread.Start();
            
            handleServerData();
        }
        catch(Exception e){
            Console.WriteLine("[Client] Unable to connect:", e.Message);
            Thread.Sleep(1000);
            clientConnect();
        }
    }
    public static void stressTestConnections(){
            string[] visaCards = {
            "4111111111111111",
            "4111222233334444",
            "4111333344445555",
            "4111444455556666",
            "4111555566667777"
            };
        
        string[] mcCards = {
            "5105105105105100",
            "5105105105105106",
            "5200202020202020",
            "5200828282828210",
            "5555555555554444"
            };

        string[] pins = {"1234", "2345", "3456", "4567", "5678"};
        
        for (int i = 0; i < 4; i++){
            Thread clientThread = new Thread(() => {
                ClientConnections clientConnection = new ClientConnections("Visa", visaCards[i], pins[i]);
                clientConnection.clientConnect();
            });
            clientThread.Start();
        }

        for (int i = 0; i < 4; i++){
            Thread clientThread = new Thread(() => {
                ClientConnections clientConnection = new ClientConnections("Mastercard", mcCards[i], pins[i]);
                clientConnection.clientConnect();
            });
            clientThread.Start();
        }
    }

    private void handleServerData(){
        int i;
        string data = null;
        byte[] buffer = new byte[256];
        try{
            while((i = stream.Read(buffer, 0, buffer.Length)) != 0){
                string json = Encoding.UTF8.GetString(buffer, 0, i);
                
                //Checks for an end of message flag and discards everything after that
                if(json.Contains("<|EOM|>")){
                    int index = json.IndexOf("<|EOM|>");
                    json = json.Substring(0, index);
                }
                else{
                    Console.WriteLine("EOM not found");
                }
                if(i > 0){
                    Request request = null;
                    try{
                        request = JsonConvert.DeserializeObject<Request>(json);
                    }
                    catch(Exception e){
                        Console.WriteLine("Error: " + e.Message);

                    }
                    if(request != null){
                        _ = Task.Run(() => handle_request(request));
                    }
                    else{
                        Console.WriteLine("Request is null");
                    }
                }
                
            }
        }
        catch(Exception e){
            Console.WriteLine("[Client] Unable to read data from server: " + e.Message);
            this.clientConnect();
        }
    }

    private void sendRandomRequest(){
        Random random = new Random();
        while(client.Connected){
            int delay = random.Next(15000,25000);
            Thread.Sleep(delay);
            Request request = new Request();
            if(random.Next(2) == 0){
                request.type = "BalanceEnq";
            }
            else{
                request.type = "Withdrawl";
                request.amount = random.Next(100, 1200).ToString();
            }
            request.card_number = this.card_number;
            request.pin = this.pin;
            request.network = this.network;
            try{
                send_request(request, stream);
            }
            catch(Exception e){
                Console.WriteLine("[Client] Unable to send request: " + e.Message);
            }
        }
    }
    public TcpClient GetTcpClient(){
        return client;
    }
    public void handle_request(Request request){
        Request response = new Request();
        
        if(request.type == "Hello"){
            Console.WriteLine("[Client] Hello message received");
            Console.WriteLine($"Card_no: {this.card_number}");
            response.type = "Hello.ATM";
            response.network = this.network;
            response.card_number = this.card_number;
            response.pin = this.pin;
            send_request(response, stream);
            response = new Request();
        }
        else if(request.type == "BalanceEnq.RESPONSE"){
            Console.WriteLine("[Client] Balance Enquiry response received");
            Console.WriteLine("Balance: " + request.amount);
        }
        else if(request.type == "Withdrawl.APPROVED"){
            Console.WriteLine("[Client] Withdrawl response recieved");
            Console.WriteLine("Status: APPROVED");
        }
        else if(request.type == "Withdrawl.DECLINED"){
            Console.WriteLine("[Client] Withdrawl response recieved");
            Console.WriteLine("Status: DECLINED");
        }
        else if(request.type == "test"){
            response.type = "Withdrawl";
            response.card_number = this.card_number;
            response.pin = this.pin;
            response.network = this.network;
            response.amount = "100";
            send_request(response, stream);
        }
        else{
            Console.WriteLine("[Client] Request type not recognized");
            Console.WriteLine("Type: " + request.type);
        }
    }

    public void ATM_send_withdrawl(string card_number, string pin, string network, string amount){
        Request request = new Request("Withdrawl", card_number, pin, network, amount, false);
        send_request(request, stream);
    }

    public void ATM_send_balance_enq(string card_number, string pin, string network){
        Request request = new Request("BalanceEnq", card_number, pin, network, "0", false);
        send_request(request, stream);
    }

    

    public static void send_request(Request request, Stream stream){
        Console.WriteLine("[Client] Sending {0} request", request.type);
        string jsonString = JsonConvert.SerializeObject(request);
        jsonString += "<|EOM|>";
        byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonString);
        stream.Write(jsonBytes, 0, jsonBytes.Length);
    }
}

//testing out visa and MC clients
class testingFuncs{
    public void atmTests(){
        // ClientConnections test = new("Visa");
        // test.clientConnect("127.0.0.1");

        // if(test.GetTcpClient() != null && test.GetTcpClient().Connected){
        //     while(true){
        //         Console.WriteLine("Running");
        //         Thread.Sleep(100000000);
        //         test.ATM_send_balance_enq("123456789", "1234", "Visa");
        //     }
        // }
        // else{
        //     Console.WriteLine("Client not connected");
        // }

    }
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

