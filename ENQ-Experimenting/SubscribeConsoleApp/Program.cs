using System;
using EasyNetQ;
using PublishConsoleAppNamespace;

namespace SubscribeConsoleAppNamespace
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("In subscriber");
            using (var bus = RabbitHutch.CreateBus("host=Ubuntu-12"))
            {
                bus.Subscribe<MyMessage>("SubscribeConsoleAppId"
                    , msg => Console.WriteLine(msg.Text));
                Console.ReadKey();
            }
        }
    }
}
