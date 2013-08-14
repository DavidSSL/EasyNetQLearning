using System;
using System.Threading;
using EasyNetQ;
using Publisher;

namespace Subscriber
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("In subscriber");
            Thread.Sleep(1000);
            using (var bus = RabbitHutch.CreateBus("host=Ubuntu-12"))
            {
                bus.Subscribe<MyMessage>("my_id", msg => Console.WriteLine(msg.Text), x => x.WithTopic("X.*"));
                Console.ReadKey();
            }
        }
    }
}
