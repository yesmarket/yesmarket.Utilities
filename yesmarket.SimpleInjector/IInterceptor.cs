namespace yesmarket.SimpleInjector
{
    public interface IInterceptor
    {
        void Intercept(IInvocation invocation);
    }
}