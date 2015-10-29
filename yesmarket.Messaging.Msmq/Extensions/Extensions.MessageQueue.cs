using System;
using System.Messaging;

namespace yesmarket.Messaging.Msmq.Extensions
{
    public static class MessageQueueExtensions
    {
        public static bool IsEmpty(this MessageQueue value)
        {
            return value.GetAllMessages().Length == 0;
        }

        public static TransactionResult InAutoTransaction(this MessageQueue value,
            Action<MessageQueue, MessageQueueTransaction> handler)
        {
            var result = new TransactionResult();
            using (var transaction = new MessageQueueTransaction())
            {
                try
                {
                    transaction.Begin();
                    handler.Invoke(value, transaction);
                    transaction.Commit();

                    result.Success = true;
                }
                catch (Exception ex)
                {
                    transaction.Abort();

                    result.Success = false;
                    result.Ex = ex;
                }
            }
            return result;
        }

        public static void InAutoTransaction(this MessageQueue value,
            Action<MessageQueue, MessageQueueTransaction> handler, Action<Exception> exceptionHandler)
        {
            using (var transaction = new MessageQueueTransaction())
            {
                try
                {
                    transaction.Begin();
                    handler.Invoke(value, transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Abort();
                    exceptionHandler.Invoke(ex);
                }
            }
        }
    }
}