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
                        Text = "Hello Rabbit"
                    };
                try
                {
                    using (var publishChannel = bus.OpenPublishChannel())
                    {
                        publishChannel.Publish(message);
                    }
                    //bus.Subscribe<MyMessage>("my_subscription_id", msg => Console.WriteLine(msg.Text));
                    //Console.ReadKey();
                }
                catch (EasyNetQException)
                {
                    // the server is not connected
                }
            }
        }
    }
}
