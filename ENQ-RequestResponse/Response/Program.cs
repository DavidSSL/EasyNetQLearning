using System;
using EasyNetQ;
using Request;

namespace Response
{
    class Program
    {
        static void Main()
        {
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
