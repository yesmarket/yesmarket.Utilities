using NHibernate;

namespace yesmarket.UnitOfWork
{
    public interface ISessionManager
    {
        ISessionFactory SessionFactory { get; }
    }
}