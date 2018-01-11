using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step4
{
    public interface IFlyBehavior { void Fly(); }
    public interface IQuackBehavior { void Quack(); }

    public abstract class Duck
    {
        public IFlyBehavior iFlyBehavior;
        public IQuackBehavior iQuackBehavior;

        public void PerformFly() { iFlyBehavior.Fly(); }
        public void PerformQuack() { iQuackBehavior.Quack(); }

        public void SetFlyBehavior(IFlyBehavior fb) { iFlyBehavior = fb; }
        public void SetQuackBehavior(IQuackBehavior qb) { iQuackBehavior = qb; }

        public void Swim() { Console.WriteLine("Can swim"); }
        public abstract void Display();
    }

    public class FlyWithWings : IFlyBehavior { public void Fly() { Console.WriteLine("Can fly"); } }
    public class FlyNoWay : IFlyBehavior { public void Fly() { Console.WriteLine("Can not fly"); } }
    public class FlyRocketPowered : IFlyBehavior { public void Fly() { Console.WriteLine("Fly with rocket"); } }

    public class QuackClass : IQuackBehavior { public void Quack() { Console.WriteLine("Quack-Quack"); } }
    public class Squeak : IQuackBehavior { public void Quack() { Console.WriteLine("Squeak-Squeak"); } }
    public class MuteQuack : IQuackBehavior { public void Quack() { Console.WriteLine("<Silent>"); } }

    public class MallardDuck : Duck
    {
        public override void Display() { Console.WriteLine("MallardDuck"); }
        public MallardDuck()
        {
            iQuackBehavior = new QuackClass();
            iFlyBehavior = new FlyWithWings();
        }
    }
    public class ReadheadDuck : Duck
    {
        public override void Display() { Console.WriteLine("ReadheadDuck"); }
        public ReadheadDuck()
        {
            iQuackBehavior = new QuackClass();
            iFlyBehavior = new FlyWithWings();
        }
    }
    public class RubberDuck : Duck
    {
        public override void Display() { Console.WriteLine("RubberDuck"); }
        public RubberDuck()
        {
            iQuackBehavior = new Squeak();
            iFlyBehavior = new FlyNoWay();
        }
    }
    public class DecoyDuck : Duck
    {
        public override void Display() { Console.WriteLine("DecoyDuck"); }
        public DecoyDuck()
        {
            iQuackBehavior = new MuteQuack();
            iFlyBehavior = new FlyNoWay();
        }
    }
    public class ModelDuck : Duck
    {
        public override void Display() { Console.WriteLine("ModelDuck"); }
        public ModelDuck()
        {
            iFlyBehavior = new FlyNoWay();
            iQuackBehavior = new QuackClass();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Duck> ducks = new List<Duck> { new MallardDuck(), new ReadheadDuck(), new RubberDuck(), new DecoyDuck() };

            foreach (Duck item in ducks)
            {
                item.Display();
                item.PerformQuack();
                item.PerformFly();
                Console.WriteLine(new string('-', 20));
            }
            Duck model = new ModelDuck();
            model.PerformFly();
            model.SetFlyBehavior(new FlyRocketPowered());
            model.PerformFly();

            Console.ReadKey();
        }
    }
}
