using System;
using System.Transactions;

namespace yesmarket.Transactions
{
    public interface ITransactionScope : IDisposable
    {
        void Complete();
    }

    public class TransactionScopeImpl : ITransactionScope
    {
        private bool _disposed;
        private TransactionScope _wrapped;

        public TransactionScopeImpl()
        {
            _wrapped = new TransactionScope();
        }

        public TransactionScopeImpl(TransactionScopeOption scopeOption)
        {
            
        }

        public TransactionScopeImpl(TransactionScopeAsyncFlowOption asyncFlowOption)
        {
            
        }

        public TransactionScopeImpl(TransactionScopeOption scopeOption, TransactionScopeAsyncFlowOption asyncFlowOption)
        {
            
        }

        public TransactionScopeImpl(TransactionScopeOption scopeOption, TimeSpan scopeTimeout)
        {
            
        }

        public TransactionScopeImpl(TransactionScopeOption scopeOption, TimeSpan scopeTimeout,
            TransactionScopeAsyncFlowOption asyncFlowOption)
        {

        }

        public TransactionScopeImpl(TransactionScopeOption scopeOption, TransactionOptions transactionOptions)
        {
            
        }

        public TransactionScopeImpl(TransactionScopeOption scopeOption, TransactionOptions transactionOptions,
            TransactionScopeAsyncFlowOption asyncFlowOption)
        {
            
        }

        public TransactionScopeImpl(TransactionScopeOption scopeOption, TransactionOptions transactionOptions,
            EnterpriseServicesInteropOption interopOption)
        {
            
        }

        public TransactionScopeImpl(Transaction transactionToUse)
        {
            
        }

        public TransactionScopeImpl(Transaction transactionToUse, TransactionScopeAsyncFlowOption asyncFlowOption)
        {
            
        }

        public TransactionScopeImpl(Transaction transactionToUse, TimeSpan scopeTimeout)
        {
            
        }

        public TransactionScopeImpl(Transaction transactionToUse, TimeSpan scopeTimeout,
            TransactionScopeAsyncFlowOption asyncFlowOption)
        {
            
        }

        public TransactionScopeImpl(Transaction transactionToUse, TimeSpan scopeTimeout,
            EnterpriseServicesInteropOption interopOption)
        {
            
        }

        public void Complete()
        {
            _wrapped.Complete();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed || !disposing) return;
            if (_wrapped != null)
            {
                _wrapped.Dispose();
                _wrapped = null;
            }
            _disposed = true;
        }
    }
}