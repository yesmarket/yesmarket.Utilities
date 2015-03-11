using System.Messaging;
using System.Transactions;

namespace yesmarket.Messaging.Msmq
{
    public class MsmqMessageQueueOutbound<T> : IMessageQueueOutbound<T>
    {
        private readonly JsonMessageFormatter _formatter = new JsonMessageFormatter();
        private readonly string _path;

        public MsmqMessageQueueOutbound(string target, string queueName)
        {
            _path = string.Format(@"{0}\private$\{1}", target, queueName);
        }

        public void Send(T message)
        {
            using (var scope = new TransactionScope())
            {
                using (var queue = new MessageQueue(_path))
                {
                    queue.DefaultPropertiesToSend.Recoverable = true;
                    queue.Formatter = _formatter;

                    queue.Send(message, MessageQueueTransactionType.Automatic);
                }

                scope.Complete();
            }
        }
    }
}