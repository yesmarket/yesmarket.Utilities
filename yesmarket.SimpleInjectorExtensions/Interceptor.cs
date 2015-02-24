using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace yesmarket.SimpleInjectorExtensions
{
    public static class Interceptor
    {
        public static T CreateProxy<T>(IInterceptor interceptor, T realInstance)
        {
            return (T) CreateProxy(typeof (T), interceptor, realInstance);
        }

        [DebuggerStepThrough]
        public static object CreateProxy(Type serviceType, IInterceptor interceptor,
            object realInstance)
        {
            var proxy = new InterceptorProxy(serviceType, realInstance, interceptor);
            return proxy.GetTransparentProxy();
        }

        private sealed class InterceptorProxy : RealProxy
        {
            private static readonly MethodBase GetTypeMethod = typeof (object).GetMethod("GetType");

            private readonly IInterceptor _interceptor;
            private readonly object _realInstance;

            [DebuggerStepThrough]
            public InterceptorProxy(Type classToProxy, object realInstance,
                IInterceptor interceptor)
                : base(classToProxy)
            {
                _realInstance = realInstance;
                _interceptor = interceptor;
            }

            public override IMessage Invoke(IMessage msg)
            {
                if (msg is IMethodCallMessage)
                {
                    var message = (IMethodCallMessage) msg;

                    if (ReferenceEquals(message.MethodBase, GetTypeMethod))
                    {
                        return Bypass(message);
                    }

                    return InvokeMethodCall(message);
                }

                return msg;
            }

            private IMessage InvokeMethodCall(IMethodCallMessage message)
            {
                var invocation =
                    new Invocation {Proxy = this, Message = message, Arguments = message.Args};

                invocation.Proceeding += () =>
                {
                    invocation.ReturnValue = message.MethodBase.Invoke(
                        _realInstance, invocation.Arguments);
                };

                _interceptor.Intercept(invocation);
                return new ReturnMessage(invocation.ReturnValue, invocation.Arguments,
                    invocation.Arguments.Length, null, message);
            }

            private IMessage Bypass(IMethodCallMessage message)
            {
                object value = message.MethodBase.Invoke(_realInstance, message.Args);

                return new ReturnMessage(value, message.Args, message.Args.Length, null, message);
            }

            private class Invocation : IInvocation
            {
                public InterceptorProxy Proxy { get; set; }
                public IMethodCallMessage Message { get; set; }
                public object[] Arguments { get; set; }
                public object ReturnValue { get; set; }

                public object InvocationTarget
                {
                    get { return Proxy._realInstance; }
                }

                public void Proceed()
                {
                    Proceeding();
                }

                public MethodBase GetConcreteMethod()
                {
                    return Message.MethodBase;
                }

                public event Action Proceeding;
            }
        }
    }
}