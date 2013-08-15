using System;
using EasyNetQ;
using NLog;

namespace SubscribeWithLoggerConsoleAppNamespace
{
    public class MyLogger:IEasyNetQLogger
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public void DebugWrite(string format, params object[] args)
        {
            Logger.Debug(string.Format(format, args));
        }

        public void InfoWrite(string format, params object[] args)
        {
            Logger.Info(string.Format(format, args));
        }

        public void ErrorWrite(string format, params object[] args)
        {
            Logger.Error(string.Format(format, args));
        }

        public void ErrorWrite(Exception exception)
        {
            Logger.ErrorException("An exception has occurred", exception);
        }
    }
}