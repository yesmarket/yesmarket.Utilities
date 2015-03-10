using NHibernate;

namespace yesmarket.UnitOfWork
{
    public interface ISessionFactoryInitializer
    {
        ISessionFactory Initialize();
    }
}