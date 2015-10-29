namespace yesmarket.Messaging.Msmq.Extensions
{
    public static class TransactionResultExtensions
    {
        public static bool ImpliesEmptyQ(this TransactionResult value)
        {
            return !value.Success && value.Ex.IsIOTimeoutMessageQueueException();
        }
    }
}