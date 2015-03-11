using System;

namespace yesmarket.Messaging
{
    public interface ITransactionScopeProvider
    {
        void Do(Action action);
    }
}