using System;
using System.Drawing;
using System.Windows.Forms;


namespace Step1
{
    internal class BeatController : IController
    {
        //Контроллер получает объекты модели и представления и связывает их воедино.
        IBeatModel model;
        Form1 view;

        //Контроллер получает модель в конструкторе и создает представление.
        public BeatController(IBeatModel model)
        {
            this.model = model;
            view = new Form1(this, model);
            view.DisabledStopMenuItem();
            model.Initialize();
            view.CreateView(view);
        }


        //При щелчке на кнопке увеличения контроллер получает текущую частоту от модели, увеличивает ее на 1- и задает результат
        //как новое значение частоты.
        public void IncreaseBPM()
        {
            int beatsPerMinute = model.GetBPM();
            if (beatsPerMinute < 200)
            {
                model.SetBPM(beatsPerMinute + 1);
            }

        }
        //То же самое, только частота уменьшается на 1. 
        public void DecreaseBPM()
        {
            int beatsPerMinute = model.GetBPM();
            if (beatsPerMinute > 1)
            {
                model.SetBPM(beatsPerMinute - 1);
            }

        }
        //public void IncreaseOrDecreaseBPM(int beatsPerMinute)
        //{
        //    model.SetBPM(beatsPerMinute);
        //}

        //ВНИМАНИЕ: все разумные решения за представление принимает контроллер. Представление умеет только устанавливать и снимать
        //блокировку команд меню; оно не знает, в каких ситуациях это следует делать.
        //При выборе команды Start контроллер активизирует модель и изменяет пользовательский интерфейс: команда Start блокируется,
        //а команда Stop становится доступной
        public void Start()
        {
            model.On();
            view.DisabledStartMenuItem();
            view.EnabledStopMunuItem();
        }

        //И наоборот, при выборе команды Stop контроллер деактивизирует модель, команда Start становится доступной, а команда Stop
        //блокируется.
        public void Stop()
        {
            model.Off();
            view.TextBoxCurrentBMP = "0";
            view.PanelColor = Color.White;
            view.DisabledStopMenuItem();        //Кнопка Stop доступна только после запуска ритма
            view.EnabledStartMunuItem();
        }

        //Наконец,, если пользователь ввел произвольную частоту, контроллер приказывает модели перейти на новое значение
        public void SetBPM(int beatsPerMinute)
        {
            model.SetBPM(beatsPerMinute);
            //view.EnabledStopMunuItem();
        }

        //public void Attach(IObserver observer)
        //{
        //    model.RegisterObserver(observer);
        //}

    }
}