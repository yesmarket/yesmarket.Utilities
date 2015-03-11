namespace yesmarket.Messaging
{
    public interface IMessageHandlerFactory<in T>
    {
        IMessageHandler<T> Create();
    }
}