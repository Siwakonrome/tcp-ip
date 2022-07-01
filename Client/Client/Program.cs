using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        // ipconfig
        const int PORT_NO = 80;
        const string SERVER_IP = "10.61.5.25";

        static void Main(string[] args)
        {
            // Get data from 3D matching
            string textToSend = "{x: 2, y: 3}"+ " " + DateTime.Now.ToString();

            TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
            Console.WriteLine("Client Start...");
            NetworkStream nwStream = client.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);
            // Sending to Server
            Console.WriteLine("Sending to Server: " + textToSend);
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);
            // Received from Server
            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
            Console.ReadLine();
            client.Close();
        }
    }
}
