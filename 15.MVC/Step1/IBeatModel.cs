using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Step1
{
    interface IBeatModel
    {
        //Методы, используемые контроллером для управления моделью на основании действий пользователя.
        void Initialize(); //Вызывается после создания экземпляра BeatModel
        void On();
        void Off();
        void SetBPM(int bmp);    // задает частоту ритма (удары в минуту).Частота изменяется сразу же после его вызова

        //Методы, при помощи которых представление и контроллер получают информацию состояния и изменяют свой статус наблюдателя.
        int GetBPM();      // возвращает текущую частоту или 0, если генератор отключен

        //Наблюдатели делятся на две группы: те, которые должны оповещаться о каждом ударе, и те, которые должны
        //оповещаться только об изменениях частоты.
        void RegisterObserver(IBeatObserver observer);
        void RemoveObserver(IBeatObserver observer);
        void RegisterObserver(IBPMObserver observer);
        void RemoveObserver(IBPMObserver observer);
    }
}
