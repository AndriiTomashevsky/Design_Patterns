using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step1
{
    // Напоминаем: паттерн Адаптер реализует целевой интерфейс
    class GooseAdapter : IQuackable
    {
        Goose goose;

        // Конмтруктор получает адаптируемый объект Goose
        public GooseAdapter(Goose goose)
        {
            this.goose = goose;
        }
        // Вызов Quack() делегируется методу Honk() класса Goose
        public void Quack()
        {
            goose.Honk();
        }
    }
}
