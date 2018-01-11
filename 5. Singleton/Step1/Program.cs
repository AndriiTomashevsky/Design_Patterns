using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step1
{
    // Singletone
    class ChocolateBoiler
    {
        static ChocolateBoiler uniqueInstance;
        private bool empty;
        private bool boiled;
        public bool IsEmpty() { return empty; }
        public bool IsBoiled() { return boiled; }

        private ChocolateBoiler() { empty = true; boiled = false; }

        public static ChocolateBoiler GetInstance()
        {
            if (uniqueInstance == null)
            {
                Console.WriteLine("Creating unique instance of Chocolate Boiler");
                uniqueInstance = new ChocolateBoiler();
            }
            Console.WriteLine("Returning instance of Chocolate Boiler");
            return uniqueInstance;
        }
        public void Fill()
        {
            if (IsEmpty())
            {
                empty = false;
                boiled = false;
            }
        }
        public void Drain()
        {
            if (!IsEmpty() && !IsBoiled())
            {
                empty = true;
            }
        }
        public void Boil()
        {
            if (!IsEmpty() && !IsBoiled())
            {
                boiled = true;
            }
        }
    }

    public class Singleton
    {
        private static Singleton _uniqueInstance;

        // other useful instance variables here

        // Constructor
        private Singleton() { }

        private static readonly object _syncLock = new object();

        public static Singleton GetInstance()
        {
            // Double checked locking
            if (_uniqueInstance == null)
            {
                lock (_syncLock)
                {
                    if (_uniqueInstance == null)
                    {
                        _uniqueInstance = new Singleton();
                    }
                }
            }
            return _uniqueInstance;
        }

        // other useful methods here
    }
    class Program
    {
        static void Main(string[] args)
        {
            var boiler = ChocolateBoiler.GetInstance();
            boiler.Fill();
            boiler.Boil();
            boiler.Drain();

            // will return the existing instance
            var boiler2 = ChocolateBoiler.GetInstance();

            // Are they the same?
            if (boiler == boiler2)
            {
                Console.WriteLine("Same instances");
            }

            var s1 = Singleton.GetInstance();
            var s2 = Singleton.GetInstance();
            var s3 = Singleton.GetInstance();

            if (s1 == s2 && s2 == s3)
            {
                Console.WriteLine("Same instances");
            }

            // Wait for user
            Console.ReadKey();
        }
    }
}
