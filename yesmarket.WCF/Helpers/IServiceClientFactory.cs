namespace yesmarket.Wcf.Helpers
{
    public interface IServiceClientFactory
    {
        TContract Get<TContract, TConcrete>(string name) where TConcrete : TContract;
    }
}