using System;
using System.Threading;
using System.Threading.Tasks;
using NLog.Interface;

namespace yesmarket.Messaging
{
    public abstract class MessageProcessor<T> : IMessageProcessor
    {
        private readonly IMessageHandlerFactory<T> _messageHandlerFactory;
        private readonly IMessageQueueInbound<T> _messageQueueInbound;
        private readonly ITransactionScopeProvider _transactionScopeProvider;
        private readonly ILogger _logger;
        private CancellationTokenSource _cancellationTokenSource;

        protected MessageProcessor(
            IMessageQueueInbound<T> messageQueueInbound,
            ITransactionScopeProvider transactionScopeProvider,
            IMessageHandlerFactory<T> messageHandlerFactory, 
            ILogger logger)
        {
            _messageQueueInbound = messageQueueInbound;
            _transactionScopeProvider = transactionScopeProvider;
            _messageHandlerFactory = messageHandlerFactory;
            _logger = logger;
        }

        public void Start()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = _cancellationTokenSource.Token;

            Task.Factory.StartNew(
                () => StartConsuming(cancellationToken),
                cancellationToken,
                TaskCreationOptions.LongRunning,
                TaskScheduler.Current);
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }

        private void StartConsuming(CancellationToken cancellationToken)
        {
            while (!cancellationToken.WaitHandle.WaitOne(0))
            {
                try
                {
                    _transactionScopeProvider.Do(() =>
                    {
                        T message;
                        if (!_messageQueueInbound.TryReceive(out message)) return;
                        using (var handler = _messageHandlerFactory.Create())
                        {
                            handler.HandleMessage(message);
                        }
                    });
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                }
            }
        }
    }
}