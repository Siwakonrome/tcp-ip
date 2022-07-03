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
        const string SERVER_IP = "192.168.101.129";
        public const byte ESC_ASCII_VALUE = 0x1b;

        static void Main(string[] args)
        {
            IPAddress localAdd = IPAddress.Parse(SERVER_IP);
            TcpListener listener = new TcpListener(localAdd, PORT_NO);
            listener.Start();
            Console.WriteLine("Server Start...");
            while (true)
            {
                Console.WriteLine("Press any key to continue! (or press ESC to quit!)");
                if (Console.ReadKey().KeyChar == ESC_ASCII_VALUE)
                    break;
                TcpClient client = listener.AcceptTcpClient();
                NetworkStream nwStream = client.GetStream();
                // Sending data to client
                string textToSend = "{" + "dateTime:" + DateTime.Now.ToString() + "}";
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);
                Console.WriteLine("Sending to client: " + Encoding.ASCII.GetString(bytesToSend, 0, bytesToSend.Length));


                // Read data from client
                byte[] buffer = new byte[client.ReceiveBufferSize];
                int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
                string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received from Server: " + dataReceived);

                Console.WriteLine("________________________________________________________________________________________");


            }
            //client.Close();
            //listener.Stop();


        }
    }
}
