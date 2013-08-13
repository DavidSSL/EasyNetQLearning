using EasyNetQ;

namespace Publisher
{
    class Program
    {
        static void Main()
        {
            using (var bus = RabbitHutch.CreateBus("host=Ubuntu-12"))
            {
                
            }
        }
    }
}
