using System;
using EasyNetQ;
using PublisherConfirm;

namespace SubscriberConfirm
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("In subscriber");
            //Thread.Sleep(1000);
            using (var bus = RabbitHutch.CreateBus("host=Ubuntu-12"))
            {
                bus.Subscribe<MyMessage>("subscriber-confirm", msg => Console.WriteLine(msg.Text));
                Console.ReadKey();
            }
        }
    }
}
