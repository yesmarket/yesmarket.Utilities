namespace yesmarket.Messaging
{
    public interface IMessageQueueOutbound<T>
    {
        void Send(T message);
    }
}
