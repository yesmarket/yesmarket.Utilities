using System;
using System.Messaging;

namespace yesmarket.Messaging.Msmq
{
    public class MsmqMessageQueueInbound<T> : IMessageQueueInbound<T>
    {
        private readonly JsonMessageFormatter _formatter = new JsonMessageFormatter();
        private readonly string _path;
        private readonly TimeSpan _timeout = TimeSpan.FromSeconds(5.0);

        public MsmqMessageQueueInbound(string queueName)
        {
            _path = string.Format(@".\private$\{0}", queueName);
            if (!MessageQueue.Exists(_path))
            {
                MessageQueue.Create(_path, true);
            }
        }

        public bool TryReceive(out T message)
        {
            try
            {
                using (var queue = new MessageQueue(_path))
                {
                    var msmqMessage = queue.Receive(_timeout, MessageQueueTransactionType.Automatic);
                    if (msmqMessage == null)
                    {
                        message = default(T);
                        return false;
                    }

                    msmqMessage.Formatter = _formatter;
                    message = (T) msmqMessage.Body;

                    return true;
                }
            }
            catch (Exception)
            {
                message = default(T);
                return false;
            }
        }
    }
}