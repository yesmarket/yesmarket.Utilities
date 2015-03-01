using System.Collections.Generic;

namespace yesmarket.WcfHelpers.FaultContracts
{
    public class ValidationFault : Fault
    {
        public ValidationFault(string message, List<string> errors)
            : base(message)
        {
            Errors = errors;
        }

        public IList<string> Errors { get; set; }
    }
}