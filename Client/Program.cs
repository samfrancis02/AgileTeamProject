﻿using System;
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


enum client_type{
    ATM,
    NETWORK
}

class ClientConnections{
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

    public string getName(){
        return this.client_name;
    }
    
    public void setName(string name){
        this.client_name = name;
    }
    
    public ClientConnections(string client_name, clientAcc client_acc, client_type type){
        this.client_name = client_name;
        this.client_acc = client_acc;
        this.type = type;
        
    }
    //class methods GENERAL FUNCTIONS
    public TcpClient clientConnect(String server){
        try{
            Int32 port = 6667;
            this.client = new TcpClient("127.0.0.1", port);
            this.stream = client.GetStream();
            Console.WriteLine("[Client] Connected to server");
            handleServerData();
            return client;
        }
        catch(Exception e){
            Console.WriteLine("[Client] Unable to connect:", e.Message);
            return null;
        }
    }

    private void handleServerData(){
        int i;
        string data = null;
        byte[] buffer = new byte[256];
        try{
            while((i = stream.Read(buffer, 0, buffer.Length)) != 0){
                string json = Encoding.UTF8.GetString(buffer, 0, i);
                Console.WriteLine("Data received");
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
                        handle_request(request);
                        Request test = new Request("BalanceEnq", "123456789", "1234", "Visa", "100", false);
                        send_request(test, stream);

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
    //class methods ATM FUNCTIONS
     //class methods NETWORK FUNCTIONS
    public void handle_request(Request request){
        Request response = new Request();
        if(request.type == "Hello"){
            Console.WriteLine("[Client] Hello message received");
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
        byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonString);
        stream.Write(jsonBytes, 0, jsonBytes.Length);
    }

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


//testing out visa and MC clients
class testingFuncs{
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
