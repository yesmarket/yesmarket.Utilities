using System.Runtime.Serialization;

namespace yesmarket.WcfHelpers.FaultContracts
{
    [DataContract]
    public class Fault
    {
        public Fault(string message)
        {
            Message = message;
        }

        [DataMember]
        public string Message { get; set; }
    }
}