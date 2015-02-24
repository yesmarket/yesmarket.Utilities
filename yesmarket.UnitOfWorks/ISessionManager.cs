using NHibernate;

namespace yesmarket.UnitOfWorks
{
    public interface ISessionManager
    {
        ISessionFactory SessionFactory { get; }
    }
}