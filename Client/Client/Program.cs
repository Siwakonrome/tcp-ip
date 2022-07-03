using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    class Program
    {
        // ipconfig
        const int PORT_NO = 80;
        const string SERVER_IP = "192.168.101.129";

        static void Main(string[] args)
        {
            TcpClient client;
            Console.WriteLine("Client Start...");
            while (true)
            {
                // Get Start client
                try{client = new TcpClient(SERVER_IP, PORT_NO);}catch{continue;}
                Console.WriteLine("Client connect with Server");
                NetworkStream nwStream = client.GetStream();
                // Received from Server
                try
                {
                    byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                    int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                    Console.WriteLine(Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
                    string data_from_server = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
                }
                catch{continue;}
                // Sending data from 3D matching
                Thread.Sleep(1000); // Do matching funtion for a while 
                string textToSend = "{" + "x:2, y:3, z:2, rx:1, ry:1, rz:3, dateTime:" + DateTime.Now.ToString() + "}";
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);
                Console.WriteLine("Sending to Server: " + textToSend);
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);
                Console.WriteLine("________________________________________________________________________________________");
            }
            //client.Close();


        }
    }
}
