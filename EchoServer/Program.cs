using System;

namespace EchoServer
{
    class Program
    {
        static void Main(string[] args)
        {
           Server worker = new Server();
           worker.Start();

           Console.ReadLine();
        }
    }
}
