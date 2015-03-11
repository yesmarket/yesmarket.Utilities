using System;
using NHibernate;
using NLog.Interface;

namespace yesmarket.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        [ThreadStatic] private static ISession _currentSession;

        private readonly ILogger _logger;
        private readonly ISessionManager _sessionManager;

        public UnitOfWork(
            ISessionManager sessionManager,
            ILogger logger)
        {
            _sessionManager = sessionManager;
            _logger = logger;
        }

        public void Do(Action<ISession> action)
        {
            if (_currentSession != null && _currentSession.IsConnected && _currentSession.IsOpen)
            {
                action.Invoke(_currentSession);
            }
            else
            {
                try
                {
                    using (var session = _sessionManager.SessionFactory.OpenSession())
                    {
                        using (var transaction = session.BeginTransaction())
                        {
                            try
                            {
                                _currentSession = session;
                                action.Invoke(session);
                                transaction.Commit();
                            }
                            catch (Exception)
                            {
                                transaction.Rollback();
                                _logger.Error("Rolling back transaction.");
                                throw;
                            }
                        }
                    }
                }
                finally
                {
                    _currentSession = null;
                }
            }
        }
    }
}