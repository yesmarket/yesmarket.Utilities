namespace yesmarket.Messaging
{
    public interface IMessageQueueInbound<T>
    {
        bool TryReceive(out T message);
    }
}
