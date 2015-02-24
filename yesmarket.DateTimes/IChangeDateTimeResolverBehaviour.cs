using System;

namespace yesmarket.DateTimes
{
    public interface IChangeDateTimeResolverBehaviour
    {
        void SetBehaviour(Func<DateTime> todayFunc, Func<DateTime> nowFunc);
    }
}