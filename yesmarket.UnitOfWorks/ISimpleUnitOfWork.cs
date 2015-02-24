using System;
using NHibernate;

namespace yesmarket.UnitOfWorks
{
    public interface ISimpleUnitOfWork
    {
        void Do(Action<ISession> action);
    }
}