using System;
using System.Messaging;

namespace yesmarket.Messaging.Msmq.Extensions
{
    public static class ExceptionExtensions
    {
        public static bool IsIOTimeoutMessageQueueException(this Exception value)
        {
            var mqex = value as MessageQueueException;
            return mqex != null && mqex.MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout;
        }
    }
}