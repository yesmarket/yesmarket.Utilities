using System;
using System.Messaging;
using System.Transactions;
using yesmarket.Messaging.Msmq.Exceptions;

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
            Action<TxHandlerException<MessageQueueTransaction>> customExceptionHandler = null)
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
                        customExceptionHandler = x =>
                        {
                            x.Transaction.Abort();
                            throw x;
                        };

                    customExceptionHandler.Invoke(new TxHandlerException<MessageQueueTransaction>(ex.Message, ex, transaction));
                }
            }
        }

        public static void InTransaction(this IMessageQueue value, Action<IMessageQueue> handler,
            Action<TxHandlerException<TransactionScope>> customExceptionHandler = null)
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
                        customExceptionHandler = x =>
                        {
                            throw x;
                        };

                    customExceptionHandler.Invoke(new TxHandlerException<TransactionScope>(ex.Message, ex, transaction));
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