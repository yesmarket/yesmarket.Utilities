using System;

namespace yesmarket.Messaging
{
    public interface IMessageHandler<in T> : IDisposable
    {
        void HandleMessage(T message);
    }
}
