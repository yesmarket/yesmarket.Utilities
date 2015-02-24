using System.Reflection;

namespace yesmarket.SimpleInjectorExtensions
{
    public interface IInvocation
    {
        object InvocationTarget { get; }
        object ReturnValue { get; set; }
        object[] Arguments { get; }
        void Proceed();
        MethodBase GetConcreteMethod();
    }
}