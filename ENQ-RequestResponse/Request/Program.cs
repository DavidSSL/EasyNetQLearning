using System;
using System.Threading;
using EasyNetQ;

namespace Request
{
    class Program
    {
        static void Main()
        {
            using (var bus = RabbitHutch.CreateBus("host=Ubuntu-12"))
            {
                Thread.Sleep(1000);
                var myRequest = new MyRequest { Text = "Hello Server" };
                using (var publishChannel = bus.OpenPublishChannel())
                {
                    publishChannel.Request<MyRequest, MyResponse>(myRequest, response =>
                        Console.WriteLine("Got response: {0}", response.Text));
                    Console.ReadKey();
                }
            }
        }
    }
}
