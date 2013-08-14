using System.Threading;
using EasyNetQ;

namespace PublishConsoleAppNamespace
{
    class Program
    {
        static void Main()
        {
            using (var bus = RabbitHutch.CreateBus("host=Ubuntu-12"))
            {
                Thread.Sleep(1000);
                
                try
                {
                    using (var publishChannel = bus.OpenPublishChannel())
                    {
                        for (var i = 0; i < 10000; i++)
                        {
                            var message = new MyMessage
                            {
                                Text = "Hello Rabbit" + i
                            };
                          
                            publishChannel.Publish(message);
                        }
                    }
                }
                catch (EasyNetQException)
                {
                    // the server is not connected
                }
            }
        }
    }
}
