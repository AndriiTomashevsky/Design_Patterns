using System;
using System.Reflection;
using System.Runtime.Remoting;

namespace Step4.ProtectionProxy
{
    /// <summary>
    /// Delegate for implementing the invocation task in a Dynamic Proxy
    /// <code>
    /// Example of an invocation handler
    /// DynamicProxyFactory.Instance.CreateProxy(testClass, new InvocationDelegate(InvocationHandler))
    /// 
    /// private static object InvocationHandler(object target, MethodBase method, object[] parameters) {
    ///		Console.WriteLine("Before: " + method.Name);
    ///		object result = method.Invoke(target, parameters);
    ///		Console.WriteLine("After: " + method.Name);
    ///		return result;
    ///	}
    /// </code>
    /// </summary>
    public delegate object InvocationDelegate(object target, MethodBase method, object[] parameters);

    // Interface for a dynamic proxy. Through this interface you can work on the proxy instance.
    public interface IDynamicProxy
    {
        // The target object for the proxy (aka. the proxied object)
        object ProxyTarget
        {
            get;
            set;
        }

        // The delegate which handles the invocation task in the dynamic proxy
        InvocationDelegate InvocationHandler
        {
            get;
            set;
        }

        // Type support strictness. Used for cast strictness
        bool Strict
        {
            get;
            set;
        }

        // List of supported types for cast strictness support. Is only checked if Strict is true
        Type[] SupportedTypes
        {
            get;
            set;
        }
    }
}
