namespace yesmarket.SimpleInjectorExtensions
{
    public interface IInterceptor
    {
        void Intercept(IInvocation invocation);
    }
}