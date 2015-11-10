using System;
using System.Messaging;
using System.Transactions;

namespace yesmarket.Messaging.Msmq.Extensions
{
    public static class MessageQueueExtensions
    {
        public static bool IsEmpty(this IMessageQueue value)
        {
            var en = value.GetMessageEnumerator2();
            return en == null || !en.MoveNext();
        }

        public static void InMessageQueueTransaction(this IMessageQueue value,
            Action<IMessageQueue, MessageQueueTransaction> handler,
            Action<MessageQueueTransaction, Exception> customExceptionHandler = null)
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
                    if (customExceptionHandler == null)
                        customExceptionHandler = (tx, x) =>
                        {
                            tx.Abort();
                            throw x;
                        };

                    customExceptionHandler.Invoke(transaction, ex);
                }
            }
        }

        public static void InTransaction(this IMessageQueue value, Action<IMessageQueue> handler,
            Action<Exception> customExceptionHandler = null)
        {
            using (var transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    handler.Invoke(value);
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    if (customExceptionHandler == null)
                        customExceptionHandler = x => { throw x; };

                    customExceptionHandler.Invoke(ex);
                }
            }
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