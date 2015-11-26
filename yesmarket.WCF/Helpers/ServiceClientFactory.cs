using System;

namespace yesmarket.Wcf.Helpers
{
    public class ServiceClientFactory : IServiceClientFactory
    {
        public TContract Get<TContract, TConcrete>(string name) where TConcrete : class, TContract
        {
            var serviceClient = Activator.CreateInstance(typeof(TConcrete), name);
            return (TContract)serviceClient;
        }
    }
}
