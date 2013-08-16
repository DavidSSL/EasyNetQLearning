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
                var myRequest = new MyRequest { Text = "Hello Server" };
                Console.WriteLine("Request started at {0}", DateTime.Now );
                using (var publishChannel = bus.OpenPublishChannel())
                {
                    publishChannel.Request<MyRequest, MyResponse>(myRequest, response =>
                        Console.WriteLine("Got response: {0}", response.Text));
                    Console.ReadKey();
                }
                Console.WriteLine("Request ended at {0}", DateTime.Now);
                Console.ReadKey();
            }
        }
    }
}
