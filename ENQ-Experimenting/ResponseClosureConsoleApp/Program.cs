using System;
using EasyNetQ;
using RequestClosureConsoleAppNamespace;
using SubscribeWithLoggerConsoleAppNamespace;

namespace ResponseClosureConsoleAppNamespace
{
    class Program
    {
        static void Main()
        {
            var logger = new MyLogger();
            Func<MyRequest, MyResponse> respond = request =>
                {
                    logger.InfoWrite("Received {0} ", request.Text);
                    return new MyResponse
                        {
                            Text = "Responding to " + request.Text
                        };
                };

            using (var bus = RabbitHutch.CreateBus("host=Ubuntu-12"))
            {
                bus.Respond(respond);
                Console.ReadKey();
            }
        }
    }
}
