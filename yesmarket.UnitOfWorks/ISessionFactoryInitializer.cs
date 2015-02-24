using NHibernate;

namespace yesmarket.UnitOfWorks
{
    public interface ISessionFactoryInitializer
    {
        ISessionFactory Initialize();
    }
}