using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СSharp_example
{
    public class Menu : MenuComponent
    {
        //IEnumerator iterator = null;

        // Этот код не изменяется
        ArrayList menuComponents = new ArrayList(); // Коллекция для хранения потомков Menu типа MenuComponent 
        string name;
        string description;

        public Menu(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        // Включение в Menu объектов MenuItem или других объектов Menu. Так как и MenuItem, и Menu расширяют MenuComponent
        // хватает одного метода.
        public override void Add(MenuComponent menuComponent)
        {
            menuComponents.Add(menuComponent);
        }
        public override void Remove(MenuComponent menuComponent)
        {
            menuComponents.Remove(menuComponent);
        }
        public override MenuComponent GetChild(int i)
        {
            return (MenuComponent)menuComponents[i];
        }
        public override string GetName()
        {
            return name;
        }
        public override string GetDescription()
        {
            return description;
        }

        public override void Print()
        {
            Console.Write("\n" + GetName());
            Console.WriteLine(", " + GetDescription());
            Console.WriteLine("---------------------");

            IEnumerator iterator = menuComponents.GetEnumerator();
            while (iterator.MoveNext())
            {
                MenuComponent menuComponent = (MenuComponent)iterator.Current;
                menuComponent.Print();
            }
        }
        // Добавлены новые метод
        public override ArrayList GetMenu()
        {
            return menuComponents;
        }
        public override int Count()
        {
            return menuComponents.Count;
        }

        //public override IEnumerator CreateIterator()
        //{
        //    if (iterator == null)
        //    {
        //        // Здесь используется новый итератор CompositeIterator. Он умеет перебирать элементы любой коллекции
        //        iterator = new CompositeIterator(menuComponents.GetEnumerator());
        //    }
        //    return iterator;
        //}
    }
}
