using System;
using System.Transactions;

namespace yesmarket.Transactions
{
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
            _wrapped = new TransactionScope(scopeOption);
        }

        public TransactionScopeImpl(TransactionScopeAsyncFlowOption asyncFlowOption)
        {
            _wrapped = new TransactionScope(asyncFlowOption);
        }

        public TransactionScopeImpl(TransactionScopeOption scopeOption, TransactionScopeAsyncFlowOption asyncFlowOption)
        {
            _wrapped = new TransactionScope(scopeOption, asyncFlowOption);
        }

        public TransactionScopeImpl(TransactionScopeOption scopeOption, TimeSpan scopeTimeout)
        {
            _wrapped = new TransactionScope(scopeOption, scopeTimeout);
        }

        public TransactionScopeImpl(TransactionScopeOption scopeOption, TimeSpan scopeTimeout,
            TransactionScopeAsyncFlowOption asyncFlowOption)
        {
            _wrapped = new TransactionScope(scopeOption, scopeTimeout, asyncFlowOption);
        }

        public TransactionScopeImpl(TransactionScopeOption scopeOption, TransactionOptions transactionOptions)
        {
            _wrapped = new TransactionScope(scopeOption, transactionOptions);
        }

        public TransactionScopeImpl(TransactionScopeOption scopeOption, TransactionOptions transactionOptions,
            TransactionScopeAsyncFlowOption asyncFlowOption)
        {
            _wrapped = new TransactionScope(scopeOption, transactionOptions, asyncFlowOption);
        }

        public TransactionScopeImpl(TransactionScopeOption scopeOption, TransactionOptions transactionOptions,
            EnterpriseServicesInteropOption interopOption)
        {
            _wrapped = new TransactionScope(scopeOption, transactionOptions, interopOption);
        }

        public TransactionScopeImpl(Transaction transactionToUse)
        {
            _wrapped = new TransactionScope(transactionToUse);
        }

        public TransactionScopeImpl(Transaction transactionToUse, TransactionScopeAsyncFlowOption asyncFlowOption)
        {
            _wrapped = new TransactionScope(transactionToUse, asyncFlowOption);
        }

        public TransactionScopeImpl(Transaction transactionToUse, TimeSpan scopeTimeout)
        {
            _wrapped = new TransactionScope(transactionToUse, scopeTimeout);
        }

        public TransactionScopeImpl(Transaction transactionToUse, TimeSpan scopeTimeout,
            TransactionScopeAsyncFlowOption asyncFlowOption)
        {
            _wrapped = new TransactionScope(transactionToUse, scopeTimeout, asyncFlowOption);
        }

        public TransactionScopeImpl(Transaction transactionToUse, TimeSpan scopeTimeout,
            EnterpriseServicesInteropOption interopOption)
        {
            _wrapped = new TransactionScope(transactionToUse, scopeTimeout, interopOption);
        }

        public void Complete()
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
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