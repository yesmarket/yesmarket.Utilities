using System;
using System.Linq.Expressions;
using SimpleInjector;

namespace yesmarket.SimpleInjector
{
    public static class ContextDependentExtensions
    {
        public static void RegisterWithContext<TService>(this Container container,
            Func<DependencyContext, TService> contextBasedFactory)
            where TService : class
        {
            if (contextBasedFactory == null)
            {
                throw new ArgumentNullException("contextBasedFactory");
            }

            Func<TService> rootFactory = () => contextBasedFactory(DependencyContext.Root);

            container.Register(rootFactory, Lifestyle.Transient);

            // Allow the Func<DependencyContext, TService> to be injected into parent types.
            container.ExpressionBuilding += (sender, e) =>
            {
                if (e.RegisteredServiceType != typeof (TService))
                {
                    var rewriter = new DependencyContextRewriter
                    {
                        ServiceType = e.RegisteredServiceType,
                        ContextBasedFactory = contextBasedFactory,
                        RootFactory = rootFactory,
                        Expression = e.Expression
                    };

                    e.Expression = rewriter.Visit(e.Expression);
                }
            };
        }

        private sealed class DependencyContextRewriter : ExpressionVisitor
        {
            internal Type ServiceType { get; set; }
            internal object ContextBasedFactory { get; set; }
            internal object RootFactory { get; set; }
            internal Expression Expression { get; set; }

            internal Type ImplementationType
            {
                get
                {
                    var expression = Expression as NewExpression;

                    if (expression != null)
                    {
                        return expression.Constructor.DeclaringType;
                    }

                    return ServiceType;
                }
            }

            protected override Expression VisitInvocation(InvocationExpression node)
            {
                if (!IsRootedContextBasedFactory(node))
                {
                    return base.VisitInvocation(node);
                }

                return Expression.Invoke(
                    Expression.Constant(ContextBasedFactory),
                    Expression.Constant(
                        new DependencyContext(ServiceType, ImplementationType)));
            }

            private bool IsRootedContextBasedFactory(InvocationExpression node)
            {
                var expression = node.Expression as ConstantExpression;

                if (expression == null)
                {
                    return false;
                }

                return ReferenceEquals(expression.Value, RootFactory);
            }
        }
    }
}