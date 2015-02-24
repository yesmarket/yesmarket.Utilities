using System;
using NHibernate;
using NLog.Interface;

namespace yesmarket.UnitOfWorks
{
    public class SimpleUnitOfWork : ISimpleUnitOfWork
    {
        private readonly ISessionManager _sessionManager;
        private readonly ILogger _logger;

        public SimpleUnitOfWork(
            ISessionManager sessionManager,
            ILogger logger)
        {
            _sessionManager = sessionManager;
            _logger = logger;
        }

        public void Do(Action<ISession> action)
        {
            using (var session = _sessionManager.SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
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
    }
}