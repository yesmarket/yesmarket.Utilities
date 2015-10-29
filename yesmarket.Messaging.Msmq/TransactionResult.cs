using System;

namespace yesmarket.Messaging.Msmq
{
    public class TransactionResult
    {
        public bool Success { get; set; }
        public Exception Ex { get; set; }
    }
}