using System;
using System.Threading;
using EasyNetQ;
using Request;

namespace Response
{
    class Program
    {
        static void Main()
        {
            Thread.Sleep(5000);

            using (var bus = RabbitHutch.CreateBus("host=Ubuntu-12"))
            {
                bus.Respond<MyRequest, MyResponse>(request => new MyResponse
                    {
                        Text = "Responding to " + request.Text
                    });
                Console.ReadKey();
            }
        }
    }
}
