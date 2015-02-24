using System;

namespace yesmarket.DateTimes
{
    public class DateTimeResolver : IDateTimeResolver, IChangeDateTimeResolverBehaviour
    {
        private Func<DateTime> _nowFunc;
        private Func<DateTime> _todayFunc;

        public DateTimeResolver()
        {
            _nowFunc = () => DateTime.Now;
            _todayFunc = () => DateTime.Today;
        }

        public DateTime Now
        {
            get { return _nowFunc(); }
        }

        public DateTime Today
        {
            get { return _todayFunc(); }
        }

        public DateTime UtcNow
        {
            get { return _nowFunc().ToUniversalTime(); }
        }

        public void SetBehaviour(Func<DateTime> todayFunc, Func<DateTime> nowFunc)
        {
            _todayFunc = todayFunc;
            _nowFunc = nowFunc;
        }
    }
}