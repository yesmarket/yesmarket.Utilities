using System.Collections.Generic;
using System.Runtime.Serialization;

namespace yesmarket.Wcf.FaultContracts
{
    [DataContract]
    public class ValidationFault : Fault
    {
        public ValidationFault(string message, IList<string> errors)
            : base(message)
        {
            Errors = errors;
        }

        [DataMember]
        public IList<string> Errors { get; set; }
    }
}