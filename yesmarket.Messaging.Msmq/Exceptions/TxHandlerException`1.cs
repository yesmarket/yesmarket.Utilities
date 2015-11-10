using System;

namespace yesmarket.Messaging.Msmq.Exceptions
{
    public class TxHandlerException<TTransaction> : Exception
    {
        public TTransaction Transaction { get; private set; }

        public TxHandlerException(TTransaction transaction)
        {
            Transaction = transaction;
        }

        public TxHandlerException(string message, TTransaction transaction)
            : base(message)
        {
            Transaction = transaction;
        }

        public TxHandlerException(string message, Exception inner, TTransaction transaction)
            : base(message, inner)
        {
            Transaction = transaction;
        }
    }
}