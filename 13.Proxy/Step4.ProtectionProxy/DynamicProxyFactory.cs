using System;

namespace Step4.ProtectionProxy
{
    /// <summary>
    /// Factory for creating Dynamic proxy instances
    /// <code>
    /// TestClasses.SimpleClass testClass = new TestClasses.SimpleClass();
    /// TestClasses.ISimpleInterface testClassProxy = (TestClasses.ISimpleInterface) DynamicProxyFactory.Instance.CreateProxy(testClass, new InvocationDelegate(InvocationHandler));
    /// testClassProxy.Method1();
    /// </code>
    /// <see cref="IDynamicProxy"/>
    /// </summary>
    public class DynamicProxyFactory
    {
        private static DynamicProxyFactory self = new DynamicProxyFactory();

        private DynamicProxyFactory()
        {
        }

        // Get the instance of the factory (singleton)
        public static DynamicProxyFactory Instance
        {
            get { return self; }
        }

        /// <summary>
        /// Create a proxy for the target object
        /// </summary>
        /// <param name="target">The object to create a proxy for</param>
        /// <param name="invocationHandler">The invocation handler for the proxy</param>
        /// <returns>The dynamic proxy instance</returns>
        public object CreateProxy(object target, InvocationDelegate invocationHandler)
        {
            return CreateProxy(target, invocationHandler, false, null);
        }

        /// <summary>
        /// Create a proxy for the target object
        /// </summary>
        /// <param name="target">The object to create a proxy for</param>
        /// <param name="invocationHandler">The invocation handler for the proxy</param>
        /// <param name="strict">Indicates if the cast support should be strict. If strict is true all casts are checked before being performed</param>
        /// <returns>The dynamic proxy instance</returns>
        public object CreateProxy(object target, InvocationDelegate invocationHandler, bool strict)
        {
            return CreateProxy(target, invocationHandler, strict, null);
        }

        /// <summary>
        /// Create a proxy for the target object
        /// </summary>
        /// <param name="target">The object to create a proxy for</param>
        /// <param name="invocationHandler">The invocation handler for the proxy</param>
        /// <param name="strict">Indicates if the cast support should be strict. If strict is true all casts are checked before being performed. The supportedType list will enabled support for more interfaces than the target object supports</param>
        /// <param name="supportedTypes">List of types that are supported for casts. Is only checked if strict is true.</param>
        /// <returns>The dynamic proxy instance</returns>
        public object CreateProxy(object target, InvocationDelegate invocationHandler, bool strict, Type[] supportedTypes)
        {
            DynamicProxyImpl dynamicProxyImpl = new DynamicProxyImpl(target, invocationHandler, strict, supportedTypes);

            // The transparent proxy provides the illusion that the actual object resides in the client's space.
            object transparentProxy = dynamicProxyImpl.GetTransparentProxy();

            return transparentProxy;
        }
    }
}
