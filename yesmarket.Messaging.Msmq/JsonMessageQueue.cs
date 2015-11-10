using System.Messaging;

namespace yesmarket.Messaging.Msmq
{
    public class JsonMessageQueue : MessageQueueImpl<JsonMessageFormatter>, IJsonMessageQueue
    {
        public JsonMessageQueue()
        {
        }

        public JsonMessageQueue(string path)
            : base(path)
        {
        }

        public JsonMessageQueue(string path, QueueAccessMode accessMode)
            : base(path, accessMode)
        {
        }

        public JsonMessageQueue(string path, bool sharedModeDenyReceive)
            : base(path, sharedModeDenyReceive)
        {
        }

        public JsonMessageQueue(string path, bool sharedModeDenyReceive, bool enableCache)
            : base(path, sharedModeDenyReceive, enableCache)
        {
        }

        public JsonMessageQueue(string path, bool sharedModeDenyReceive, bool enableCache,
            QueueAccessMode accessMode)
            : base(path, sharedModeDenyReceive, enableCache, accessMode)
        {
        }
    }
}