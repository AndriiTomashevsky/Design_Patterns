using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// А почему перебор в комбинациях намного сложнее кода перебора, написанного нами для метода print() класса MenuComponent?
// При написании метода print() класса MenuComponent мы использовали итератор для перебора всех узлов компонента.Если узел был объектом Menu(а не Menultem), 
// то для его обработки рекурсивно вызывался метод print(). Иначе говоря, объект MenuComponent выполнял перебор сам, в своей внутренней реализации.
// В этом коде реализуется внешний итератор, поэтому нам приходится учитывать много дополнительных обстоятельств.Для начала внешний итератор должен сохранять те- 
// кущую позицию перебора, чтобы внешний клиент мог управлять перебором, вызывая методы hasNextQ и next(). Но в нашей ситуации код должен сохранять текущую по- 
// зицию в комбинационной рекурсивной структуре.По этой причине для отслеживания текущей позиции при перемещении вверх-вниз по комбинационной иерархии используются стеки. 

namespace СSharp_example
{
    // CompositeIterator перебирает элементы MenuItem в Menu, а также следит за тем, чтобы в перебор были включены все 
    // дочерные меню (а также их дочерные меню и т.д.)
    public class CompositeIterator : IEnumerator
    {
        Stack stack = new Stack();

        // В конструктор передается итератор комбинации верхнего уровня
        public CompositeIterator(IEnumerator iterator)
        {
            stack.Push(iterator);
        }

        public object Current
        {
            get
            {
                if (MoveNext())
                {
                    IEnumerator iterator = (IEnumerator)stack.Peek();
                    // Если следующий элемент существует, мы извлекаем текущий итератор из стека и получаем следующий элемент 
                    MenuComponent component = (MenuComponent)iterator.Current;    // "Рекурсия - мой друг, рекурсия - мой друг..."
                    if (component is Menu)
                    {
                        //stack.Push(component.CreateIterator());
                    }
                    return component;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool MoveNext()
        {
            if (stack.Count == 0)
            {
                return false;
            }
            else
            {
                IEnumerator iterator = (IEnumerator)stack.Peek();
                if (!iterator.MoveNext())
                {
                    stack.Pop();
                    return MoveNext();          // "Рекурсия - мой друг, рекурсия - мой друг..."
                }
                else
                {
                    return true;
                }
            }
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        /*
         * No longer needed as of Java 8
         * 
         * (non-Javadoc)
         * @see java.util.Iterator#remove()
         *
        public void remove() {
            throw new UnsupportedOperationException();
        }
        */
    }
}
