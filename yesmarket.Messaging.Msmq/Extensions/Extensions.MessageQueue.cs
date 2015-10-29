using System;
using System.Messaging;
using PoC;

namespace yesmarket.Messaging.Msmq.Extensions
{
    public static class MessageQueueExtensions
    {
        public static bool IsEmpty(this MessageQueue value)
        {
            using (var enumerator = value.GetMessageEnumerator2())
            {
                return !enumerator.MoveNext();
            }

            //try
            //{
            //    value.Peek(timeSpan);
            //    return false;
            //}
            //catch (Exception)
            //{
            //    //do-nothing
            //}
            //return true;
        }

        private static Message Peek2(this MessageQueue value)
        {
            using (var enumerator = value.GetMessageEnumerator2())
            {
                return enumerator.MoveNext() ? enumerator.Current : null;
            }
        }

        public static TransactionResult InAutoTransaction(this MessageQueue value, Action<MessageQueue, MessageQueueTransaction> action)
        {
            var result = new TransactionResult();
            using (var transaction = new MessageQueueTransaction())
            {
                try
                {
                    transaction.Begin();
                    action.Invoke(value, transaction);
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
    }
}