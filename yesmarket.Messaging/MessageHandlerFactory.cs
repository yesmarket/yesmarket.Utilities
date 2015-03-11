using System;

namespace yesmarket.Messaging
{
    public class MessageHandlerFactory<T> : IMessageHandlerFactory<T>
    {
        private readonly Func<IMessageHandler<T>> _factory;

        public MessageHandlerFactory(Func<IMessageHandler<T>> factory)
        {
            _factory = factory;
        }

        public IMessageHandler<T> Create()
        {
            return _factory.Invoke();
        }
    }
}