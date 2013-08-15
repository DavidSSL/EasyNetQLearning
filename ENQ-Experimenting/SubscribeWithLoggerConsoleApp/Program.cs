using EasyNetQ;
using PublishConsoleAppNamespace;

namespace SubscribeWithLoggerConsoleAppNamespace
{
    class Program
    {
        static void Main()
        {
            var logger = new MyLogger();
            logger.InfoWrite("In subscriber");
            var bus = RabbitHutch.CreateBus("host=Ubuntu-12", x => x.Register<IEasyNetQLogger>(_ => logger));

            bus.Subscribe<MyMessage>("SubscribeWithLoggerConsoleAppId"
                                     , msg => logger.InfoWrite(msg.Text));
        }
    }
}
