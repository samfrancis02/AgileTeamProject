using System;
using System.ComponentModel.Design;
using System.IO;
using System.IO.Pipes;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Microsoft.VisualBasic;
using System.Text.Json;
using Newtonsoft.Json; //Dependancy!! use "dotnet add package Newtonsoft.Json --version 13.0.3" to install


enum client_type{
        ATM,
        NETWORK
    }  

class network_server{
    public static void Main(){
        testingFuncs test = new();
        test.clientTests();
    }
    public ATMClient[] ATMClients;
    public NetworkClient[] NetworkClients;
    private X509Certificate cert; //Will be used when implementing security features
    
    public network_server(){
        //arrays to store current clients in
        ATMClients = new ATMClient[10];
        NetworkClients = new NetworkClient[10];
    }
    public void Start_Server(){
        TcpListener sim_server = null;
        
        try{
            //Setting port to 6667 and using localhost
            Int32 port = 6667;
            IPAddress local_ip = IPAddress.Any;
            sim_server = new TcpListener(local_ip, port);

            //Start listening for requests
            sim_server.Start();

            //Buffer for incoming data
            Byte[] buffer = new Byte[256];
            String data = null;
            int i;
            //loop around listening for new clients
            while(true){
                Console.WriteLine("[Server] Listening on port 6667...");
                
                //Accept incoming request
                using TcpClient client = sim_server.AcceptTcpClient();
                
                Console.WriteLine("[Server]: User Connected");
                
                //handle incoming data, reset data varible for use
                data = null;
                NetworkStream stream = client.GetStream();
                
                //Sends an intial request to client for details
                Request new_request = new Request();
                new_request.type = "Hello";
                send_request(new_request, stream);

                //reads incoming data
                i = stream.Read(buffer, 0, buffer.Length);
                Request request = null;
                //converts incoming data to a request object
                string json = Encoding.UTF8.GetString(buffer, 0, i);
                request = JsonConvert.DeserializeObject<Request>(json.TrimEnd('\0'));
                Console.WriteLine("[Server] Request Info: {0}", request.type);

                //determines client type based off intial request
                if(request.type.Length > 1){
                    if(request.type == "Hello.NETWORK"){
                        NetworkClient network_client = new NetworkClient(request.network, client, stream);
                        NetworkClients.Append(network_client);
                        this.handle_network_client(network_client, stream);
                    }
                    else if(request.type == "Hello.ATM"){
                        ATMClient atm_client = new ATMClient(request.card_number, request.pin, request.network, client, stream);
                        ATMClients.Append(atm_client);
                        this.handle_atm_client(atm_client, stream);
                    }
                    else{
                        Console.WriteLine("Client type not found");
                        client.Close();
                    }
                    Console.WriteLine("[Server] Request Info: {0}", request.type);
                }
                else{
                    client.Close();
                }
            }
        }

        catch(SocketException e){
            Console.WriteLine("Sokcet Exception: {0}: ", e);
        } 
    }

    //function to send a message to a client
    void send_request(Request request, NetworkStream stream){
        Console.WriteLine("[Server] Sending Request");
        byte[] msg = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(request);
        stream.Write(msg, 0, msg.Length);
    }

    //function to handle network clients
   void handle_network_client(NetworkClient client, NetworkStream stream){
        Byte[] buffer = new Byte[256];
        string data = null;
        int i;
        Console.WriteLine("Succesffuly determined client type");
   
        try{
        while((i = stream.Read(buffer, 0, buffer.Length)) != 0){
                string json = Encoding.UTF8.GetString(buffer, 0, i);
                
                if(i > 0){
                    Console.WriteLine("Data received{0}", json);
                    Request request = null;
                    try{
                        request = JsonConvert.DeserializeObject<Request>(json.TrimEnd('\0'));
                    }
                    catch(Exception e){
                        Console.WriteLine("Exception: {0}", e);
                    }
                    if(request != null){
                        handle_ATM_data(request);
                        //handle_network_data(request, client, stream);
                    }
                    else{
                        Console.WriteLine("Request is null");
                    }
                }
            }
        }
        catch(IOException e){
            Console.WriteLine("IOException: {0}", e);
        }
        catch(Exception e){
            Console.WriteLine("Exception: {0}", e);
        }
        finally{
            stream.Close();
            client.client.Close();
        }
    }
    //Function that takes data recived from a card network, and sends a relevant response/request to an ATM client
    public void handle_network_data(Request request, NetworkClient client, NetworkStream stream){
        if(request.type == "Withdrawl"){
            Console.WriteLine("[Server] Network: Withdrawl Requested");
            for(int j = 0; j < ATMClients.Length; j++){
                if(ATMClients[j].getCardNumber() == request.card_number){
                    send_request(request, ATMClients[j].stream);
                }
                else{
                    Console.WriteLine("Card not found");
                }
            }
        }
        if(request.type == "BalanceEnq"){
            Console.WriteLine("[Server] Network: BalanceEnq Requested");
            for(int j = 0; j < ATMClients.Length; j++){
                if(ATMClients[j].getCardNumber() == request.card_number){
                    Console.WriteLine("Card found, Balance Requested: {0}", request.amount);
                    send_request(request, ATMClients[j].stream);
                }
                else{
                    Console.WriteLine("Card not found");
                }
            }
        }
    }

    //function that handles ATM clients
    private void handle_atm_client(ATMClient client, NetworkStream stream){
        
        Byte[] buffer = new Byte[256];
        string data = null;
        int i;
        try{
            while((i = stream.Read(buffer, 0, buffer.Length)) != 0){
                    string json = Encoding.UTF8.GetString(buffer, 0, i);
                    if(i > 0){
                        Console.WriteLine("Data received{0}", json);
                        Request request = null;
                        try{
                            request = JsonConvert.DeserializeObject<Request>(json.TrimEnd('\0'));
                        }
                        catch(Exception e){
                            Console.WriteLine("Exception: {0}", e);
                        }
                        if(request != null){
                            handle_ATM_data(request);
                        }
                        else{
                            Console.WriteLine("Request is null");
                        }
                    }
            }
        }
        catch(IOException e){
            Console.WriteLine("IOException: {0}", e);
        }
        catch(Exception e){
            Console.WriteLine("Exception: {0}", e);
        }
        finally{
            stream.Close();
            client.client.Close();
        }
    }
    
    //function that takes data recived from an ATM client, and sends a relevant response/request to a card network
    private void handle_ATM_data(Request request){
        if(request.type == "Withdrawl"){
            Console.WriteLine("[Server] ATM: Withdrawl Requested");
            for(int j = 0; j < NetworkClients.Length; j++){
                if(NetworkClients[j].getNetworkName() == request.network){
                    send_request(request, NetworkClients[j].stream);
                }
                else{
                    Console.WriteLine("Card network not found");
                }
            }
        }
        if(request.type == "BalanceEnq"){
            Console.WriteLine("[Server] ATM: BalanceEnq Requested");
            for(int j = 0; j < NetworkClients.Length; j++){
                if(NetworkClients[j].getNetworkName() == request.network){
                    Console.WriteLine("Card network found, Balance Requested: {0}", request.amount);
                    send_request(request, NetworkClients[j].stream);
                }
                else{
                    Console.WriteLine("Card network not found");
                }
            }
        }
    }
}
//class for server to store current clients in 
class Client{
    public TcpClient client{get; set;}
    public NetworkStream stream {get; set;}
    private client_type type {get; set;}

    public void setType(client_type type){
        this.type = type;
    }
       
}

//child class of client for ATM clients
class ATMClient : Client{
    private string card_number {get;}
    private string pin {get;}
    private string network {get;}
    public ATMClient(string card_number, string pin, string network, TcpClient client, NetworkStream stream){

        this.setType(client_type.ATM);
        this.card_number = card_number;
        this.pin = pin;
        this.network = network;
        this.client = client;
        this.stream = stream;
    }

    public string getCardNumber(){
        return this.card_number;
    }

}

//chold class for networks such as visa and mastercard
class NetworkClient : Client{
    private string networkName {get;}
    public NetworkClient(string networkName, TcpClient client, NetworkStream stream){
        setType(client_type.NETWORK);
        this.networkName = networkName;
        this.client = client;
        this.stream = stream;
    }

    public string getNetworkName(){
        return this.networkName;
    }
}

//class for storing client account information
class clientAcc{
    public string card_number;
    public string network;
    public string pin; 


}

class Request{
    public string type {get; set;}
    public string card_number {get; set;}
    public string pin {get; set;}
    public string network {get; set;}
    public string amount {get; set;}
    public bool response {get; set;}

//object type for a request to sent to and from the server
    public Request(){
        this.type = "";
        this.card_number = "";
        this.pin = "";
        this.network = "";
        this.amount = "";
        this.response = false;
    }

      public Request(string type, string card_number, string pin, string network, string amount, bool response){
        this.type = type;
        this.card_number = card_number;
        this.pin = pin;
        this.network = network;
        this.amount = amount;
        this.response = response;
    }

}

//class for testing functions
class testingFuncs{
    public void clientTests(){
        network_server myServer = new network_server();
        myServer.Start_Server();
    }

}