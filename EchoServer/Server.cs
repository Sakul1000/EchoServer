using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EchoServer
{
    class Server
    {
        public void Start()
        {
            // opret server
            // ip egen computer (samme som 127.0.0.1), port er applikationen her en ekko server derfor port 7
            TcpListener server = new TcpListener(IPAddress.Loopback, 7);
            server.Start();



            while (true)
            {
                // venter på en klient skal lave et opkald
                TcpClient socket = server.AcceptTcpClient();
                Task.Run(() =>
                {
                    TcpClient tempSocket = socket;
                    DoClient(tempSocket);

                });

            }
        }

        private static void DoClient(TcpClient socket)
        {
            //net stream 
            NetworkStream ns = socket.GetStream();

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            // læs tekst fra klient
            String str = sr.ReadLine();
            Console.WriteLine($"Her er server input: {str}");

            Thread.Sleep(5000);

            // skriv tilbage til klient
            String UpperStr = str.ToUpper();
            sw.WriteLine(UpperStr);
            sw.Flush(); // tømmer buffer

            socket.Close();
         

        }
    }
}
