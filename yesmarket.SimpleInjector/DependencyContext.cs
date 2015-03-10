using System;
using System.Diagnostics;

namespace yesmarket.SimpleInjector
{
    [DebuggerDisplay("DependencyContext (ServiceType: {ServiceType}, ImplementationType: {ImplementationType})")]
    public class DependencyContext
    {
        internal static readonly DependencyContext Root = new DependencyContext();

        internal DependencyContext(Type serviceType, Type implementationType)
        {
            ServiceType = serviceType;
            ImplementationType = implementationType;
        }

        private DependencyContext()
        {
        }

        public Type ServiceType { get; private set; }
        public Type ImplementationType { get; private set; }
    }
}