using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        const int PORT_NO = 80;
        const string SERVER_IP = "10.61.5.18"; 

        static void Main(string[] args)
        {
            TcpClient client;
            IPAddress localAdd = IPAddress.Parse(SERVER_IP);
            TcpListener listener = new TcpListener(localAdd, PORT_NO);
            listener.Start();
            while (true)
            {
                try { client = listener.AcceptTcpClient(); } catch { continue; }
                NetworkStream nwStream = client.GetStream();
                try
                {
                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
                    string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Received from Server: " + dataReceived);
                }catch{continue;}
                string textToSend = "{" + "dateTime:" + DateTime.Now.ToString() + "}";
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);
                Console.WriteLine("Sending to client: " + Encoding.ASCII.GetString(bytesToSend, 0, bytesToSend.Length));
                Console.WriteLine("__________________________________________________________________________________");
            }




        }
    }
}
