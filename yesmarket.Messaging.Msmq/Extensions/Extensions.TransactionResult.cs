using System.Messaging;
using PoC;

namespace yesmarket.Messaging.Msmq.Extensions
{
    public static class TransactionResultExtensions
    {
        public static bool ImpliesEmptyQ(this TransactionResult value)
        {
            if (value.Success) return false;
            var mqex = value.Ex as MessageQueueException;
            return mqex != null && mqex.MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout;
        }
    }
}