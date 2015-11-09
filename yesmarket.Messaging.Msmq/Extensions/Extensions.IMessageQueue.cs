using System;
using System.Messaging;
using System.Transactions;

namespace yesmarket.Messaging.Msmq.Extensions
{
    public static class MessageQueueExtensions
    {
        public static bool IsEmpty(this IMessageQueue value)
        {
            return value.GetAllMessages().Length == 0;
        }

        public static TransactionResult InMessageQueueTransaction(this IMessageQueue value,
            Action<IMessageQueue, MessageQueueTransaction> handler)
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

        public static TransactionResult InTransaction(this IMessageQueue value,
            Action<IMessageQueue> handler)
        {
            var result = new TransactionResult();
            using (var transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    handler.Invoke(value);
                    transaction.Complete();

                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Ex = ex;
                }
            }
            return result;
        }

        public static void WhileNotEmpty(this IMessageQueue value, Action<IMessageQueue> action)
        {
            var en = value.GetMessageEnumerator2();
            if (!en.MoveNext()) return;
            do
            {
                try
                {
                    action.Invoke(value);
                }
                catch (MessageQueueException ex)
                {
                    // This handles a rare scenario whereby another process receives the last message off the Q before this instance. 
                    // This will cause a timeout exception, so this exception handler is basically a fail safe.
                    if (!en.MoveNext() && ex.MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout) break;
                }
            } while (en.MoveNext());
        }
    }
}