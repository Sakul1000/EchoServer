using System;

namespace EchoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client worker = new Client();
            worker.start();

            Console.ReadLine();

        }
    }
}
