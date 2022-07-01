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
        const string SERVER_IP = "10.61.5.25";

        static void Main(string[] args)
        {
            IPAddress localAdd = IPAddress.Parse(SERVER_IP);
            TcpListener listener = new TcpListener(localAdd, PORT_NO);
            listener.Start();
            Console.WriteLine("Server Start...");
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                // Read data from client
                NetworkStream nwStream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];
                int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
                string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received from Server: " + dataReceived);
                // Sending data back to client
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes("Capture" + " " + DateTime.Now.ToString());
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);
                Console.WriteLine("Sending back : " + Encoding.ASCII.GetString(bytesToSend, 0, bytesToSend.Length));
                //Console.ReadLine();
            }
            //client.Close();
            //listener.Stop();


        }
    }
}
