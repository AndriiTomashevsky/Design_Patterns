using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Collections.Generic;

namespace Step4.ProtectionProxy
{
    class Program
    {
        Dictionary<string, IPerson> datingDB = new Dictionary<string, IPerson>();

        IPerson GetPersonFromDatabase(string name)
        {
            return datingDB[name];
        }

        void InitializeDatabase()
        {
            IPerson joe = new Person
            {
                Name = "Joe Javabean",
                Interest = "cars, computers, music",
                HotOrNotRating = 7
            };
            datingDB.Add(joe.Name, joe);

            IPerson kelly = new Person
            {
                Name = "Kelly Klosure",
                Interest = "ebay, movies, music",
                HotOrNotRating = 6
            };
            datingDB.Add(kelly.Name, kelly);
        }

        public Program()
        {
            InitializeDatabase();
        }

        object OwnerInvocationHandler(object target, MethodBase method, object[] parameters)
        {
            object result = null;

            try
            {
                if (!method.Name.Equals("set_HotOrNotRating"))
                {
                    result = method.Invoke(target, parameters);
                }
                else
                {
                    throw new UnauthorizedAccessException("You are not permitted to rate yourself");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Can't set rating from owner proxy");
                //return ex.StackTrace;
            }

            return result;
        }

        object NonOwnerInvocationHandler(object target, MethodBase method, object[] parameters)
        {
            object result = null;

            try
            {
                if (method.Name.Equals("set_HotOrNotRating"))
                {
                    result = method.Invoke(target, parameters);
                }
                else if (method.Name.Equals("get_HotOrNotRating"))
                {
                    result = method.Invoke(target, parameters);
                }
                else if (method.Name.Equals("get_Name"))
                {
                    result = method.Invoke(target, parameters);
                }
                else if (method.Name.Equals("get_Interest"))
                {
                    result = method.Invoke(target, parameters);
                }
                else
                {
                    throw new UnauthorizedAccessException("You are not permitted to update another's personal information!");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("You are not permitted to update another's personal information!");
                //return ex.StackTrace;
            }

            return result;
        }

        void Drive()
        {
            // Чтение записи из БД
            IPerson joe = GetPersonFromDatabase("Joe Javabean");

            DynamicProxyFactory dynamicProxyFactory = DynamicProxyFactory.Instance;

            // Создание заместителя для владельца
            IPerson ownerTransparentProxy =
                (IPerson)dynamicProxyFactory.CreateProxy(joe, new InvocationDelegate(OwnerInvocationHandler));

            Console.WriteLine("Name is " + ownerTransparentProxy.Name);

            ownerTransparentProxy.Interest = "bowling, Go";
            Console.WriteLine("Interests set from owner proxy");

            ownerTransparentProxy.HotOrNotRating = 10;     // "Can't set rating from owner proxy"

            Console.WriteLine("Rating is " + ownerTransparentProxy.HotOrNotRating); // "Rating is 7" 

            Console.WriteLine(new string('-', 30));

            // Создание заместителя для не владельца
            IPerson nonOwnerTransparentProxy =
                (IPerson)dynamicProxyFactory.CreateProxy(joe, new InvocationDelegate(NonOwnerInvocationHandler));

            Console.WriteLine("Name is " + nonOwnerTransparentProxy.Name);

            nonOwnerTransparentProxy.Interest = "ebay, movies, music"; // "You are not permitted to update another's personal information!"

            nonOwnerTransparentProxy.HotOrNotRating = 3;                // This should work
            Console.WriteLine("Rating set from non owner proxy");      
            Console.WriteLine("Rating is " + nonOwnerTransparentProxy.HotOrNotRating);  // "Rating is 5" ((3+7)/2)
        }

        static void Main(string[] args)
        {
            Program test = new Program();
            test.Drive();

            Console.ReadKey();
        }

    }
}
