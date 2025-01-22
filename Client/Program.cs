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

enum client_type{
    ATM,
    NETWORK
}

class ClientConnections{
    public static void Main(){
        testingFuncs test = new();
        test.clientTests();
    }
    private Timer checkTimer;
    //decleration and constructor
    private string client_name;
    public clientAcc client_acc;
    private TcpClient client;
    private NetworkStream stream;
    private client_type type;
    
    
    public ClientConnections(string client_name, clientAcc client_acc, client_type type){
        this.client_name = client_name;
        this.client_acc = client_acc;
        this.type = type;
        
    }
    //class methods
    public TcpClient clientConnect(String server){
        try{
            Int32 port = 6667;
            this.client = new TcpClient("127.0.0.1", port);
            this.stream = client.GetStream();
            Console.WriteLine("[Client] Connected to server");
            
            //Server will intially send message asking for details, this is the reponse
            byte[] data; 
            data = new byte[256];
            int bytes = stream.Read(data, 0, data.Length);
            string response = Encoding.UTF8.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", response);

            data = System.Text.Encoding.UTF8.GetBytes(this.type.ToString() + "," + this.client_name);
            stream.Write(data, 0, data.Length);
            checkTimer = new Timer(SendKeepAlive, null, 0, 5000);
            return client;
        }
        catch(Exception e){
            Console.WriteLine("[Client] Unable to connect:", e.Message);
            return null;
        }
    }
    private void SendKeepAlive(object state){
       try{
       if(client != null && client.Connected){
           byte[] msg = System.Text.Encoding.UTF8.GetBytes("KeepAlive");
           stream.Write(msg, 0, msg.Length);
       }
       }
       catch(Exception e){
           Console.WriteLine("[Client] Unable to send keep alive: " + e.Message);
           this.clientConnect("");
       }
    }
    public TcpClient GetTcpClient(){
        return client;
    }
}

class clientAcc{
    public string card_number;
    public string network;
    public string pin;

    public clientAcc(string card_number, string network, string pin){
        this.card_number = card_number;
        this.network = network;
        this.pin = pin;
    }
}

class testingFuncs{
    public void clientTests(){
        clientAcc test_acc = new("1234567890", "Visa", "1234");
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

}
