using System;
using System.Collections.Generic;
using System.Globalization;
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

            string[] SplitListe = str.Split(" ");

            //sætter de 2 lister sammen
            double MathValue = double.Parse(SplitListe[1], new CultureInfo("en-UK")) 
                               + double.Parse(SplitListe[2], new CultureInfo("en-UK"));

            // skriv tilbage til klient
            String UpperStr = str.ToUpper();
            sw.WriteLine(MathValue);
            sw.Flush(); // tømmer buffer

            socket.Close();
         

        }
    }
}
