using System;
using System.Threading;
using EasyNetQ;
using SubscribeWithLoggerConsoleAppNamespace;

namespace RequestClosureConsoleAppNamespace
{
    class Program
    {
        static void Main()
        {
            var logger = new MyLogger();

            using (var bus = RabbitHutch.CreateBus("host=Ubuntu-12"))
            {
                var myRequest = new MyRequest();

                using (var publishChannel = bus.OpenPublishChannel())
                {
                    for (var i = 0; i < 5; i++)
                    {
                        myRequest.Text = "Send to Response Server " + i;
                        publishChannel.Request<MyRequest, MyResponse>(myRequest, response =>
                                                                                logger.InfoWrite(
                                                                                     "Got response: {0}", response.Text));
                        //Thread.Sleep(500);
                    }
                    Console.ReadKey();
                }
            }
        }
    }
}
