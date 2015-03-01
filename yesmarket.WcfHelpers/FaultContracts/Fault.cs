namespace yesmarket.WcfHelpers.FaultContracts
{
    public class Fault
    {
        public Fault(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}