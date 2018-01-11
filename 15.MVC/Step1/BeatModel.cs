using System;
using System.Timers;


namespace Step1
{
    public delegate void BeatHundler();

    // Observable
    class BeatModel : IBeatModel
    {
        //Timer object fires its System.Timers.Timer.Elapsed event every 500 milliseconds, sets up an event handler for the event, 
        //and starts the timer. 
        private Timer timer;

        //События, на которые могут подписыватся две категории наблюдателей
        public event BeatHundler BeatEvent;
        public event BeatHundler BPMEvent;

        private int beatsPerMinute = 90; // Частота ритма, по умолчанию 120

        //The time, in milliseconds, between events.
        private int interval = 500;

        //Implement IBeatModel
        #region 
        // Метод настраивает генератор и готовит музыку для воспроизведения
        public void Initialize()
        {
            timer = new Timer();
            timer.Interval = interval;

            //Method that occurs when the interval elapses
            timer.Elapsed += OnTimedEvent;
        }

        //Запускает генератор и устанавливает частоту по умолчанию(120 beatsPerMinute). 
        public void On()
        {
            //Начинает вызывать событие System.Timers.Timer.Elapsed, задавая для свойства System.Timers.Timer.Enabled значение true.
            timer.Start();
        }

        //Oстанавливает генератор и задает частоту равной О.
        public void Off()
        {
            //Прекращает вызывать событие System.Timers.Timer.Elapsed, задавая для свойства System.Timers.Timer.Enabled значение false.
            timer.Stop();
        }

        // Используется контроллером для управления ритмом. Выполняет три операции:
        public void SetBPM(int beatsPerMinute)
        {
            //(1)Присваивание значения переменной beatsPerMinute
            this.beatsPerMinute = beatsPerMinute;

            //(2)Запрос генератору на изменение частоты
            interval = (int)((60D / beatsPerMinute) * 1000D);
            timer.Interval = interval;

            //(3)Оповещение всех наблюдателей об изменении частоты
            NotifyBPMObservers();
            NotifyBeatObservers();
        }

        public int GetBPM()
        {
            return beatsPerMinute;
        }

        public void RegisterObserver(IBeatObserver observer)
        {
            BeatEvent += observer.UpdateBeat;
        }

        public void RemoveObserver(IBeatObserver observer)
        {
            BeatEvent -= observer.UpdateBeat;
        }

        public void RegisterObserver(IBPMObserver observer)
        {
            BPMEvent += observer.UpdateBPM;
        }

        public void RemoveObserver(IBPMObserver observer)
        {
            BPMEvent -= observer.UpdateBPM;
        }
        #endregion //Implement IBeatModel

        private void NotifyBeatObservers()
        {
            // Update display of observers
            OnBeat();
        }

        private void NotifyBPMObservers()
        {
            // Update display of observers
            OnBPM();
        }

        // Invoke the Beat event
        private void OnBeat()
        {
            if (BeatEvent != null)
            {
                BeatEvent.Invoke();
            }

        }
        // Invoke the BPM event
        private void OnBPM()
        {
            if (BPMEvent != null)
            {
                BPMEvent.Invoke();
            }
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            try
            {
                // old XP support
                Console.Beep(2000, 10);

                // Vista / Windows 7 support
                System.Media.SystemSounds.Beep.Play();
            }
            catch { } // Do nothing

            // Let the observers know about this beat
            //Так как установлен интервал 500 милисекунд, представление получает оповещения каждые 1/2 секунды.
            //(цвет полосы обновляется каждые 1/2 секунды)
            NotifyBPMObservers();
            NotifyBeatObservers();
        }
    }
}
