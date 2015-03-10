using System;
using System.Runtime.Remoting.Messaging;
using NHibernate;
using NLog.Interface;

namespace yesmarket.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        const string Key = "yesmarket.UnitOfWork";

        private readonly ISessionManager _sessionManager;
        private readonly ILogger _logger;

        public UnitOfWork(
            ISessionManager sessionManager,
            ILogger logger)
        {
            _sessionManager = sessionManager;
            _logger = logger;
        }

        public void Do(Action<ISession> action)
        {
            var contextSession = CallContext.GetData(Key) as ISession;

            if (contextSession == null)
            {
                using (var session = _sessionManager.SessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        try
                        {
                            CallContext.SetData(Key, session);
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
            else
            {
                action.Invoke(contextSession);
            }
        }
    }
}