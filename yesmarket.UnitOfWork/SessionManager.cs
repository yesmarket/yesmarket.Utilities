using NHibernate;

namespace yesmarket.UnitOfWork
{
    public class SessionManager : ISessionManagerInitializer, ISessionManager
    {
        private readonly ISessionFactoryInitializer _sessionFactoryInitializer;

        public SessionManager(
            ISessionFactoryInitializer sessionFactoryInitializer)
        {
            _sessionFactoryInitializer = sessionFactoryInitializer;
        }

        public void Initialize()
        {
            var sessionFactory = _sessionFactoryInitializer.Initialize();
            SessionFactory = sessionFactory;
        }

        public ISessionFactory SessionFactory { get; private set; }
    }
}