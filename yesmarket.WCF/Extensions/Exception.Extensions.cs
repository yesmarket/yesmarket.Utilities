using System;
using yesmarket.Wcf.FaultContracts;

namespace yesmarket.Wcf.Extensions
{
    public static class ExceptionExtensions
    {
        public static Fault ToFault(this Exception value)
        {
            return new Fault(value.Message);
        }
    }
}
