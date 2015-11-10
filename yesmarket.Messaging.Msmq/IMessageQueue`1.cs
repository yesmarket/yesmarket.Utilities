using System.Messaging;

namespace yesmarket.Messaging.Msmq
{
    public interface IMessageQueue<TFormatter> : IMessageQueue where TFormatter : IMessageFormatter
    {
    }
}