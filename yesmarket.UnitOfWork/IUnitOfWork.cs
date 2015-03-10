using System;
using NHibernate;

namespace yesmarket.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Do(Action<ISession> action);
    }
}