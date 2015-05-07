using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        public static Hashtable clientsList = new Hashtable();

        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(8888);
            TcpClient clientSocket = default(TcpClient);
            int counter = 0;

            serverSocket.Start();
            Console.WriteLine("Chat Server Started ....");
            counter = 0;
            while ((true))
            {
                counter += 1;
                clientSocket = serverSocket.AcceptTcpClient();

                byte[] bytesFrom = new byte[10025];
                string dataFromClient = null;
              
                NetworkStream networkStream = clientSocket.GetStream();
                networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                clientsList.Add(dataFromClient, clientSocket);

                broadcast(dataFromClient + " Joined ", dataFromClient, false);
               

                Console.WriteLine(dataFromClient + " Joined chat room ");
                handleClinet client = new handleClinet();
                client.startClient(clientSocket, dataFromClient, clientsList);

            }

        
        }

        public static void broadcast(string msg, string uName, bool flag)
        {
            foreach (DictionaryEntry Item in clientsList)
            {
                TcpClient broadcastSocket;
                broadcastSocket = (TcpClient)Item.Value;
                NetworkStream broadcastStream = broadcastSocket.GetStream();
                Byte[] broadcastBytes = null;

                if (flag == true)
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(uName + " says : " + msg);
                }
                else
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(msg);
                }

                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                broadcastStream.Flush();
            }
        }  
        public static void broadcast(string msg, string uName)
        {
            clientsList.Remove(uName);
            foreach (DictionaryEntry Item in clientsList)
            {
              
               
                
                    TcpClient broadcastSocket;
                    broadcastSocket = (TcpClient)Item.Value;
                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    Byte[] broadcastBytes = null;




                    broadcastBytes = Encoding.ASCII.GetBytes(uName + " " + msg);


                    broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    broadcastStream.Flush();
                
            }
        }
    }


    public class handleClinet
    {
        TcpClient clientSocket;
        string clNo;
        Hashtable clientsList;
     
        public void startClient(TcpClient inClientSocket, string clineNo, Hashtable cList)
        {
            this.clientSocket = inClientSocket;
            this.clNo = clineNo;
            this.clientsList = cList;
            Thread ctThread = new Thread(doChat);
            ctThread.Start();
            ctThread.IsBackground = true;

        }

        private void doChat()
        {
            connectedUsers();
        
            byte[] bytesFrom = new byte[10025];
            string dataFromClient = null;
         
            string rCount = null;
       
            Boolean exv = true;
            while ((exv))
            {
                try
                {
                   
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    Console.WriteLine("From client - " + clNo + " : " + dataFromClient);
                   

                    Program.broadcast(dataFromClient, clNo, true);
                }
                catch (Exception ex)
                {
                    exv = false;
                    Console.WriteLine(clNo + "  " + "Left chat server");
                    Program.broadcast(""+"Left chat server", clNo);
                    connectedUsers();
                }
            }

        }

        public void connectedUsers() {
            String users="";
            foreach (string value in clientsList.Keys)
            {
                users += value + ",";
            }
            Program.broadcast("Connected Users "+users,"Server",false);
        }
        
        } 
    }

