using System;

namespace yesmarket.Transactions
{
    public interface ITransactionScope : IDisposable
    {
        void Complete();
    }
}