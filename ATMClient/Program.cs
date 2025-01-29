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
    public static void Main(){
        testingFuncs test = new();
        test.atmTests();
    }
    //decleration and constructor
    private string client_name;
    private TcpClient client;
    private NetworkStream stream;

    public string getName(){
        return this.client_name;
    }
    
    public void setName(string name){
        this.client_name = name;
    }
    
    public ClientConnections(string client_name){
        this.client_name = client_name;
    }
    //class methods GENERAL FUNCTIONS
    public void clientConnect(String server){
        try{
            Int32 port = 6667;
            this.client = new TcpClient("127.0.0.1", port);
            this.stream = client.GetStream();
            Console.WriteLine("[Client] Connected to server");
            handleServerData();
        }
        catch(Exception e){
            Console.WriteLine("[Client] Unable to connect:", e.Message);
            Thread.Sleep(1000);
            clientConnect("");
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
                        handle_request(request);
                    }
                    else{
                        Console.WriteLine("Request is null");
                    }
                }
                
            }
        }
        catch(Exception e){
            Console.WriteLine("[Client] Unable to read data from server: " + e.Message);
            this.clientConnect("");
        }
    }
    public TcpClient GetTcpClient(){
        return client;
    }
    public void handle_request(Request request){
        Request response = new Request();
        
        if(request.type == "Hello"){
            Console.WriteLine("[Client] Hello message received");
            response.type = "Hello.ATM";
            response.network = "Visa";
            response.card_number = "123456789";
            response.pin = "1234";
            send_request(response, stream);
            response = new Request();
        }
        else if(request.type == "BalanceEnq.RESPONSE"){
            Console.WriteLine("[Client] Balance Enquiry response received");
            Console.WriteLine("Balance: " + request.amount);
        }
        else if(request.type == "Withdrawl"){
            Console.WriteLine("[Client] Withdrawl response recieved");
            Console.WriteLine("Status: " + request.response);
        }
        else if(request.type == "Test"){
            response.type = "BalanceEnq";
            response.card_number = "123456789";
            response.pin = "1234";
            response.network = "Visa";
            response.amount = "0";
            send_request(response, stream);
        }
        else{
            Console.WriteLine("[Client] Request type not recognized");
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
        ClientConnections test = new("Visa");
        test.clientConnect("127.0.0.1");

        if(test.GetTcpClient() != null && test.GetTcpClient().Connected){
            while(true){
                Console.WriteLine("Running");
                Thread.Sleep(100000000);
                test.ATM_send_balance_enq("123456789", "1234", "Visa");
            }
        }
        else{
            Console.WriteLine("Client not connected");
        }

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

