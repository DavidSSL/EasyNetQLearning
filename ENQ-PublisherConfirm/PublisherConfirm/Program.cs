using System;
using System.Diagnostics;
using System.Threading;
using EasyNetQ;

namespace PublisherConfirm
{
    class Program
    {
        static void Main()
        {
            using (var bus = RabbitHutch.CreateBus("host=Ubuntu-12"))
            {
                const int batchSize = 5000;
                var callbackCount = 0;
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                var confirmCount = 0;
                var nonConfirmedCount = 0;

                using (var channel = bus.OpenPublishChannel(x => x.WithPublisherConfirms()))
                {
                    for (int i = 0; i < batchSize; i++)
                    {
                        var message = new MyMessage { Text = string.Format("Hello Message {0}", i) };
                        channel.Publish(message, x =>
                            x.OnSuccess(() =>
                            {
                                callbackCount++;
                                confirmCount++;
                            })
                            .OnFailure(() =>
                            {
                                callbackCount++;
                                nonConfirmedCount++;
                            }));
                    }

                    // wait until all the publications have been acknowleged.
                    while (callbackCount < batchSize)
                    {
                        if (stopwatch.Elapsed.Seconds > 10)
                        {
                            throw new ApplicationException("Aborted batch with timeout");
                        }
                        Thread.Sleep(10);
                    }
                    Console.WriteLine("The confirmed count is: {0}.", confirmCount);
                    Console.WriteLine("The non confirmed count is: {0}", nonConfirmedCount);
                    Console.ReadKey();
                }
            }
        }
    }
}
