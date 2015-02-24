using System;

namespace yesmarket.DateTimes
{
    public interface IDateTimeResolver
    {
        DateTime Now { get; }
        DateTime Today { get; }
        DateTime UtcNow { get; }
    }
}
