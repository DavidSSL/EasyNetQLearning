using EasyNetQ;

namespace Publisher
{
    class Program
    {
        static void Main()
        {
            using (var bus = RabbitHutch.CreateBus("host=Ubuntu-12"))
            {
                var message = new MyMessage
                {
                    Text = "Hello Rabbit in Topic"
                };
                try
                {
                    using (var publishChannel = bus.OpenPublishChannel())
                    {
                        publishChannel.Publish(message, x => x.WithTopic("X.A"));
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
