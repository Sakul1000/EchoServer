using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace EchoClient
{
    class Client
    {
        public void start()
        {
            //client opretter forbindelse til server der ligger på "localhost" og port 7
            TcpClient socket = new TcpClient("localhost",7);

           

            StreamReader sr = new StreamReader(socket.GetStream());
            StreamWriter sw = new StreamWriter(socket.GetStream());


            string strSomSendes = "hej lukas hvordan går det?";
            sw.WriteLine(strSomSendes);
            sw.Flush();

            string strRetur = sr.ReadLine();
            Console.WriteLine($"Tilbage fra server : {strRetur} ");

            socket.Close();




        }

    }
}
