using System.Messaging;

namespace yesmarket.Messaging.Msmq
{
    public class JsonMessageQueueImpl : MessageQueueImpl<JsonMessageFormatter>, IJsonMessageQueue
    {
        public JsonMessageQueueImpl()
        {
        }

        public JsonMessageQueueImpl(JsonMessageFormatter formatter)
            : base(formatter)
        {
        }

        public JsonMessageQueueImpl(string path)
            : base(path)
        {
        }

        public JsonMessageQueueImpl(string path, JsonMessageFormatter formatter)
            : base(path, formatter)
        {
        }

        public JsonMessageQueueImpl(string path, QueueAccessMode accessMode)
            : base(path, accessMode)
        {
        }

        public JsonMessageQueueImpl(string path, QueueAccessMode accessMode, JsonMessageFormatter formatter)
            : base(path, accessMode, formatter)
        {
        }

        public JsonMessageQueueImpl(string path, bool sharedModeDenyReceive)
            : base(path, sharedModeDenyReceive)
        {
        }

        public JsonMessageQueueImpl(string path, bool sharedModeDenyReceive, JsonMessageFormatter formatter)
            : base(path, sharedModeDenyReceive, formatter)
        {
        }

        public JsonMessageQueueImpl(string path, bool sharedModeDenyReceive, bool enableCache)
            : base(path, sharedModeDenyReceive, enableCache)
        {
        }

        public JsonMessageQueueImpl(string path, bool sharedModeDenyReceive, bool enableCache,
            JsonMessageFormatter formatter)
            : base(path, sharedModeDenyReceive, enableCache, formatter)
        {
        }

        public JsonMessageQueueImpl(string path, bool sharedModeDenyReceive, bool enableCache,
            QueueAccessMode accessMode)
            : base(path, sharedModeDenyReceive, enableCache, accessMode)
        {
        }

        public JsonMessageQueueImpl(string path, bool sharedModeDenyReceive, bool enableCache,
            QueueAccessMode accessMode, JsonMessageFormatter formatter)
            : base(path, sharedModeDenyReceive, enableCache, accessMode, formatter)
        {
        }
    }
}