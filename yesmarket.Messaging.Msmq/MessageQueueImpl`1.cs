using System;
using System.Messaging;

namespace yesmarket.Messaging.Msmq
{
    public class MessageQueueImpl<TFormatter> : MessageQueueImpl, IMessageQueue<TFormatter>
        where TFormatter : IMessageFormatter
    {
        public MessageQueueImpl()
            : this((TFormatter) Activator.CreateInstance(typeof (TFormatter)))
        {
        }

        internal MessageQueueImpl(TFormatter formatter)
        {
            Formatter = formatter;
        }

        public MessageQueueImpl(string path)
            : this(path, (TFormatter) Activator.CreateInstance(typeof (TFormatter)))
        {
        }

        internal MessageQueueImpl(string path, TFormatter formatter)
            : base(path)
        {
            Formatter = formatter;
        }

        public MessageQueueImpl(string path, QueueAccessMode accessMode)
            : this(path, accessMode, (TFormatter) Activator.CreateInstance(typeof (TFormatter)))
        {
        }

        internal MessageQueueImpl(string path, QueueAccessMode accessMode, TFormatter formatter)
            : base(path, accessMode)
        {
            Formatter = formatter;
        }

        public MessageQueueImpl(string path, bool sharedModeDenyReceive)
            : this(path, sharedModeDenyReceive, (TFormatter) Activator.CreateInstance(typeof (TFormatter)))
        {
        }

        internal MessageQueueImpl(string path, bool sharedModeDenyReceive, TFormatter formatter)
            : base(path, sharedModeDenyReceive)
        {
            Formatter = formatter;
        }

        public MessageQueueImpl(string path, bool sharedModeDenyReceive, bool enableCache)
            : this(path, sharedModeDenyReceive, enableCache, (TFormatter) Activator.CreateInstance(typeof (TFormatter)))
        {
        }

        internal MessageQueueImpl(string path, bool sharedModeDenyReceive, bool enableCache, TFormatter formatter)
            : base(path, sharedModeDenyReceive, enableCache)
        {
            Formatter = formatter;
        }

        public MessageQueueImpl(string path, bool sharedModeDenyReceive, bool enableCache, QueueAccessMode accessMode)
            : this(
                path, sharedModeDenyReceive, enableCache, accessMode,
                (TFormatter) Activator.CreateInstance(typeof (TFormatter)))
        {
        }

        internal MessageQueueImpl(string path, bool sharedModeDenyReceive, bool enableCache, QueueAccessMode accessMode,
            TFormatter formatter)
            : base(path, sharedModeDenyReceive, enableCache, accessMode)
        {
            Formatter = formatter;
        }
    }
}