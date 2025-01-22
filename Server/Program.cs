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
            while(true){
                Console.WriteLine("[Server] Listening on port 6667...");
                
                //Accept incoming request
                using TcpClient client = sim_server.AcceptTcpClient();
                
                Console.WriteLine("[Server]: User Connected");
                
                //handle incoming data, reset data varible for use
                data = null;
                NetworkStream stream = client.GetStream();
                
                //Sends an intial request to client for details
                byte[] msg = System.Text.Encoding.UTF8.GetBytes("[Server] Welcome to server: Requesting Details...\n");
                stream.Write(msg, 0, msg.Length);
                
                //receive data from client and store in client_info, then split data
                i = stream.Read(buffer, 0, buffer.Length);
                string client_info = Encoding.UTF8.GetString(buffer,0,i);
                string[] client_data = handle_data(client_info);

                //checks for type of client connectecting and handles accordingly
                if(client_data[0] == "NETWORK"){
                    NetworkClient network_client = new NetworkClient(client_data[1], client, stream);
                    NetworkClients.Append(network_client);
                    handle_network_client(network_client);
                }
                Console.WriteLine("[Server] Client Info: {0}", client_data[0]);
            }
        }

        catch(SocketException e){
            Console.WriteLine("Sokcet Exception: {0}: ", e);
        } 
    }
    private static void handle_network_client(NetworkClient client){
        //creates a stream for the client
        NetworkStream stream = client.client.GetStream();
        Byte[] buffer = new Byte[256];
        string data = null;
        int i;
        Console.WriteLine("Network name: {0}", client.getNetworkName());
        try{
        while((
            //reads incoming data from the client
            i = stream.Read(buffer, 0, buffer.Length)) != 0){
            data = Encoding.UTF8.GetString(buffer, 0, i);
            Console.WriteLine($"[Server] Received: {data}");

            //Responds to Clients peridoic keep alive messages
            if(data == "KeepAlive"){
                Console.WriteLine("[Server] KeepAlive Requested");
                byte[] msg = System.Text.Encoding.UTF8.GetBytes("ACK");
                stream.Write(msg, 0, msg.Length);
                }
            }
            //trying to implement leave here
            // if(data == "FIN" || data == "RST"){
            //     Console.WriteLine("[Server] Client Disconnected");
            //     foreach(Client client1 in NetworkClients){

            //     }
            // }
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
    //
    //  Commnented out ATM Client handling network client for now 
    //
    // private static void handle_atm_client(ATMClient client){
    //     NetworkStream stream = client.client.GetStream();
    //     Byte[] buffer = new Byte[256];
    //     string data = null;
    //     int i;
    //     Console.WriteLine("Network name: {0}", client.getNetworkName());
    //     try{
    //     while((i = stream.Read(buffer, 0, buffer.Length)) != 0){
    //         data = Encoding.UTF8.GetString(buffer, 0, i);
    //         Console.WriteLine($"[Server] Received: {data}");

    //         if(data == "KeepAlive"){
    //             Console.WriteLine("[Server] KeepAlive Requested");
    //             byte[] msg = System.Text.Encoding.UTF8.GetBytes("ACK");
    //             stream.Write(msg, 0, msg.Length);
    //             }
    //         }
    //     }
    //     catch(IOException e){
    //         Console.WriteLine("IOException: {0}", e);
    //     }
    //     catch(Exception e){
    //         Console.WriteLine("Exception: {0}", e);
    //     }
    //     finally{
    //         stream.Close();
    //         client.client.Close();
    //     }
    // }
   
   //Splits incoming data by string
    private static string[] handle_data(string data){
        data = data.ToUpper();
        string[] indv_data = data.Split(",");
        return indv_data;
    }
}

//class for server to store current clients in 
class Client{
    public TcpClient client{get; set;}
    public Stream stream {get; set;}
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
    private string name {get;}
    public ATMClient(client_type type, string card_number, string pin, string network, string name, TcpClient client, Stream stream){
        type = client_type.ATM;
        this.card_number = card_number;
        this.pin = pin;
        this.network = network;
        this.name = name;
        this.client = client;
        this.stream = stream;
    }

}

//chold class for networks such as visa and mastercard
class NetworkClient : Client{
    private string networkName {get;}
    public NetworkClient(string networkName, TcpClient client, Stream stream){
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

//class for testing functions
class testingFuncs{
    public void clientTests(){
        network_server myServer = new network_server();
        myServer.Start_Server();
    }

}