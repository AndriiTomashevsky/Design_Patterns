using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step5
{
    class Duck : IComparable
    {
        string name;
        int weight;

        public Duck(string name, int weight)
        {
            this.name = name;
            this.weight = weight;
        }

        public int CompareTo(object obj)
        {
            Duck otherDuck = (Duck)obj;

            if (weight < otherDuck.weight)
            {
                return -1;
            }
            else if (weight == otherDuck.weight)
            {
                return 0;
            }
            else // weight > otherDuck.weight
            {
                return 1;
            }
        }
        public override string ToString()
        {
            return name + " weight " + weight;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Duck[] ducks = {
                        new Duck("Daffy", 8),
                        new Duck("Dewey", 2),
                        new Duck("Howard", 7),
                        new Duck("Louie", 2),
                        new Duck("Donald", 10),
                        new Duck("Huey", 2)
         };

            Console.WriteLine("Before sorting:");
            Display(ducks);

            Array.Sort(ducks);  

            Console.WriteLine("\nAfter sorting:");
            Display(ducks);

            Console.ReadKey();
        }
        public static void Display(Duck[] ducks)
        {
            for (int i = 0; i < ducks.Length; i++)
            {
                Console.WriteLine(ducks[i]);
            }
        }
    }
}
