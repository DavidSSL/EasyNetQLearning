using System;
using System.Net;
using EasyNetQ;
using PublishConsoleAppNamespace;
using SubscribeWithLoggerConsoleAppNamespace;

namespace SubscribeAsyncConsoleAppNamespace
{
    class Program
    {
        static void Main()
        {
            var logger = new MyLogger();
            logger.InfoWrite("In subscriber");
            var bus = RabbitHutch.CreateBus("host=Ubuntu-12");

            bus.SubscribeAsync<MyMessage>("SubscribeAsyncConsoleAppId", msg =>
                new WebClient().DownloadStringTaskAsync(new Uri("http://ubuntu-12/"))
                .ContinueWith(task =>
                    logger.InfoWrite("Received '{0}', Downloaded{1}", msg.Text, task.Result))
                );
        }
    }
}
