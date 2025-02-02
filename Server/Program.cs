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
<<<<<<< HEAD
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.Threading.Tasks; //Dependancy!! use "dotnet add package Newtonsoft.Json --version 13.0.3" to install
=======
using Newtonsoft.Json; //Dependancy!! use "dotnet add package Newtonsoft.Json --version 13.0.3" to install
>>>>>>> main


enum client_type{
        ATM,
        NETWORK
    }  

class network_server{
<<<<<<< HEAD
    public static async Task Main(){
        network_server myServer = new network_server();
        await myServer.Start_Server();
    }
    private TcpListener sim_server;
    public List <ATMClient> ATMClients;
    public List <NetworkClient> NetworkClients;
=======
    public static void Main(){
        testingFuncs test = new();
        test.clientTests();
    }
    public ATMClient[] ATMClients;
    public NetworkClient[] NetworkClients;
>>>>>>> main
    private X509Certificate cert; //Will be used when implementing security features
    
    public network_server(){
        //arrays to store current clients in
<<<<<<< HEAD
        ATMClients = new List<ATMClient>();
        NetworkClients = new List<NetworkClient>();
    }    
    public async Task Start_Server(){
        try{
            //Setting port to 6667 and using localhost
            Int32 port = 6667;
            IPAddress localAddr = IPAddress.Any;
            sim_server = new TcpListener(localAddr, port);
            
            //Start listening for requests
            sim_server.Start();
            Console.WriteLine("[Server] Listening on port 6667...");

            //loop around listening for new clients
            while(true){
                TcpClient client = await sim_server.AcceptTcpClientAsync();
                //aync task to handle intial request
                _ = Task.Run(() => handle_intial_request(client));
            }
        }
        catch(SocketException e){
            Console.WriteLine("Socket Exception: {0}", e);
        }
        catch(Exception e){
            Console.WriteLine("Exception: {0}", e);
        }
        finally{
            sim_server.Stop();
        }
    }

    private async Task accept_connection(){
        Console.WriteLine("[Server] Accepting Connection");
        TcpClient client = await sim_server.AcceptTcpClientAsync();
    }
    private void handle_intial_request(TcpClient client){
        NetworkStream stream = client.GetStream();

        //send intial request to client
        Request new_request = new Request();
        new_request.type = "Hello";
        send_request(new_request, stream);

        //determine client type
        byte[] buffer = new byte[256];
        int i = stream.Read(buffer, 0, buffer.Length);
        string json = Encoding.UTF8.GetString(buffer, 0, i);
        if(json.Contains("<|EOM|>")){
            int index = json.IndexOf("<|EOM|>");
            json = json.Substring(0, index);
        }
        else{
            Console.WriteLine("EOM not found");
        }
        Request request = JsonConvert.DeserializeObject<Request>(json.TrimEnd('\0'));
        if(request.type == "Hello.NETWORK"){
            NetworkClient network_client = new NetworkClient(request.network, client, stream);
            NetworkClients.Add(network_client);
            _ = Task.Run(() => handle_network_client(network_client, stream));
        }
        else if(request.type == "Hello.ATM"){
            Console.WriteLine("[Server]: User Connected: {0}", request.type);
            Console.WriteLine($"Card Number: {request.card_number}, Pin: {request.pin}, Network: {request.network}");
            ATMClient atm_client = new ATMClient(request.card_number, request.pin, request.network, client, stream);
            ATMClients.Add(atm_client);
            _ = Task.Run(() => handle_atm_client(atm_client, stream));
        }
        else{
            Console.WriteLine("Client type not found");
            client.Close();
        }
=======
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
>>>>>>> main
    }

    //function to send a message to a client
    void send_request(Request request, NetworkStream stream){
<<<<<<< HEAD
         Console.WriteLine("[Server] Sending {0} request", request.type);
        string jsonString = JsonConvert.SerializeObject(request);
        jsonString += "<|EOM|>";
        log(request);
        byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonString);
        stream.Write(jsonBytes, 0, jsonBytes.Length);
=======
        Console.WriteLine("[Server] Sending Request");
        byte[] msg = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(request);
        stream.Write(msg, 0, msg.Length);
>>>>>>> main
    }

    //function to handle network clients
   void handle_network_client(NetworkClient client, NetworkStream stream){
        Byte[] buffer = new Byte[256];
        string data = null;
        int i;
<<<<<<< HEAD
        Console.WriteLine("Network Client {0} Connected", client.getNetworkName());
        try{
        while((i = stream.Read(buffer, 0, buffer.Length)) != 0){
                string json = Encoding.UTF8.GetString(buffer, 0, i);
                if(json.Contains("<|EOM|>")){
                    int index = json.IndexOf("<|EOM|>");
                    json = json.Substring(0, index);
                }
                else{
                    Console.WriteLine("EOM not found");
                }
=======
        Console.WriteLine("Succesffuly determined client type");
   
        try{
        while((i = stream.Read(buffer, 0, buffer.Length)) != 0){
                string json = Encoding.UTF8.GetString(buffer, 0, i);
                
>>>>>>> main
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
<<<<<<< HEAD
                        handle_network_data(request, client, stream);
=======
                        handle_ATM_data(request);
                        //handle_network_data(request, client, stream);
>>>>>>> main
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
<<<<<<< HEAD
        if(request.type == "Withdrawl.APPROVED"){
            Console.WriteLine("[Server] Network: Withdrawl Response, sending to appropriate ATM");
            int index = ATMClients.FindIndex(x => x.getCardNumber() == request.card_number);
            if(index != -1){
                send_request(request, ATMClients[index].stream);
            }
            else{
                Console.WriteLine("ATM not found");
        }
        }
        else if(request.type == "Withdrawl.DECLINED"){
            Console.WriteLine("[Server] Network: Withdrawl Response, sending to appropriate ATM");
            int index = ATMClients.FindIndex(x => x.getCardNumber() == request.card_number);
            if(index != -1){
                send_request(request, ATMClients[index].stream);
            }
            else{
                Console.WriteLine("atm not found");
            }
        }
        else if(request.type == "BalanceEnq.RESPONSE"){
            Console.WriteLine("[Server] Network: BalanceEnq Response, sending to appropriate ATM");
            int index = ATMClients.FindIndex(x => x.getCardNumber() == request.card_number);
            if(index != -1){
                send_request(request, ATMClients[index].stream);
            }
            else{
                Console.WriteLine("atm not found");
            }
        }
    
    }

    private void log(Request request){
        string logging = DateAndTime.Now + " " + request.type + " " + request.card_number + " " + request.network + " " + request.amount + "\n";
        File.AppendAllText("log.txt", logging);
=======
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
>>>>>>> main
    }

    //function that handles ATM clients
    private void handle_atm_client(ATMClient client, NetworkStream stream){
<<<<<<< HEAD
        Request request1 = new Request();
        request1.type = "test";
        send_request(request1, stream);
=======
        
>>>>>>> main
        Byte[] buffer = new Byte[256];
        string data = null;
        int i;
        try{
            while((i = stream.Read(buffer, 0, buffer.Length)) != 0){
<<<<<<< HEAD
                    Console.WriteLine("Data received");
                    string json = Encoding.UTF8.GetString(buffer, 0, i);
                    //checks for EOM and discards everything after that point
                    if(json.Contains("<|EOM|>")){
                        int index = json.IndexOf("<|EOM|>");
                        json = json.Substring(0, index);
                    }
                    else{
                        Console.WriteLine("EOM not found");
                    }
=======
                    string json = Encoding.UTF8.GetString(buffer, 0, i);
>>>>>>> main
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
<<<<<<< HEAD
        Console.WriteLine("ATMRequest type: {0}", request.type);
        if(request.type == "Withdrawl"){
            Console.WriteLine("[Server] ATM: Withdrawl Requested");
            int index = NetworkClients.FindIndex(x => x.getNetworkName().ToLower() == request.network.ToLower());
            if(index != -1){
                send_request(request, NetworkClients[index].stream);
            }
            else{
                Console.WriteLine("Card network not found");
            }
        }
        if(request.type == "BalanceEnq"){
            Console.WriteLine("[Server] ATM: BalanceEnq Requested on {0}", request.network);
            int index = NetworkClients.FindIndex(x => x.getNetworkName().ToLower() == request.network.ToLower());
            if(index != -1){
                send_request(request, NetworkClients[index].stream);
            }
            else{
                Console.WriteLine("Card network not found");
=======
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
>>>>>>> main
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
<<<<<<< HEAD
        //List of types
        //Hello: Intial request for details, will be sent to all clients who join
        //Hello.ATM for ATM clients
        //Hello.NETWORK for network clients
        //Withdrawl: Request to withdraw money
        //Withdrawl.RESPONSE: Response to withdrawl request
        //BalanceEnq: Request to check balance
        //BalanceEnq.RESPONSE: Response to balance request
=======
>>>>>>> main
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
<<<<<<< HEAD
    public async Task clientTests(){
        network_server myServer = new network_server();
        await myServer.Start_Server();
=======
    public void clientTests(){
        network_server myServer = new network_server();
        myServer.Start_Server();
>>>>>>> main
    }

}