using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step3
{
    //Мы определяем абстрактную фабрику, которая будет реализовываться субклассами для создания разных продуктов
    abstract class AbstractDuckFactory
    {
        //Каждый метод создает одну из разновидностей уток
        public abstract IQuackable CreateMallardDuck();
        public abstract IQuackable CreateRedheadDuck();
        public abstract IQuackable CreateDuckCall();
        public abstract IQuackable CreateRubberDuck();
    }
}
