using System;
using System.Drawing;
using System.Windows.Forms;

//ПРЕДСТАВЛЕНИЕ
//Определяет представление модели.Как правило, представление получает состояние и данные для отображения непосредственно от модели.

namespace Step1
{
    // View
    //Form1 — наблюдатель для событий обоих видов (удары в реальном времени и изменения частоты).
    partial class Form1 : Form, IBeatObserver, IBPMObserver  
    {
        //В представлении хранятся ссылки на модель и на контроллер. Контроллер используется только управляющими элементами
        private IController controller;
        private IBeatModel model;

        // Two 'beatable' observer controls (см.Form1.Designer.InitializeComponent())
        //private BeatTextBox textBoxCurrentBMP;   //Индикатор текущей частоты; автоматически обновляется при ее изменении.
        //private BeatPanel panelColor;           // Пульсирующая(цветная) полоска отображает ритм в реальном времени.

        public Form1(IController controller, IBeatModel model)
        {
            //Конструктор получает ссылки на контроллер и модель и сохраняет их в переменных. 
            this.controller = controller;
            this.model = model;
            InitializeComponent();

            //Представление регистрируется в качестве наблюдателя IBeatObserver и IBPMObserver модели.
            model.RegisterObserver((IBeatObserver)this);
            model.RegisterObserver((IBPMObserver)this);
        }
        internal void CreateView(Form1 view)
        {
            Application.Run(view);
        }

        //Пользователь либо вводит конкретное значение и щелкает на кнопке Set... 
        // Set the beat
        private void buttonSet_Click(object sender, EventArgs e)
        {
            int beatsPerMinute = int.Parse(textBoxBMP.Text);
            controller.SetBPM(beatsPerMinute);
        }

        //...либо использует кнопки (скролл) увеличения и уменьшения для более точной регулировки.
        // Update the pulse (см.Form1.Designer.InitializeComponent())
        // Occurs when either a mouse or keyboard action moves the scroll box.
        private void trackBarBPM_Scroll(object sender, EventArgs e)
        {
            int beatsPerMinute = trackBarBPM.Value;
            controller.SetBPM(beatsPerMinute);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            controller.Stop();
        }

        // Make stop button accessible to controller
        public void DisabledStopMenuItem()
        {
            buttonStop.Enabled = false;
        }

        public void EnabledStopMunuItem()
        {
            buttonStop.Enabled = true;
        }

        //Implement IBeatObserver
        public void UpdateBeat()
        {
            // Depending on beatsPerMinute set color anywhere between red and yellow
            int red = 255;
            //Представление оповещается об изменении частоты. Оно вызывает метод GetBPM() для получения состояния модели. 
            int green = 255 - (model.GetBPM() + 55);
            int blue = 0;

            //Gets or sets the background color for the control
            //Полоска индикатора «пульсирует» в такт ритма, получая информацию об ударах от оповещений BeatObserver.
            panelColor.BackColor = Color.FromArgb(red, green, blue); //Пульсирующая(цветная) полоска отображает ритм в реальном времени.
        }

        //Implement IBPMbserver
        public void UpdateBPM()
        {
            //Представление оповещается об изменении частоты. Оно вызывает метод GetBPM() для получения состояния модели. 
            //Вызывается при изменении состояния модели
            textBoxCurrentBMP.Text = model.GetBPM().ToString(); //Индикатор текущей частоты; автоматически обновляется при ее изменении.
                                                                //Текущая частота,полученная из оповещений BPMObserver.
            trackBarBPM.Value = model.GetBPM();
        }

        public string TextBoxCurrentBMP
        {
            set
            {
                textBoxCurrentBMP.Text = value;
            }
        }

        public Color PanelColor
        {
            set
            {
                panelColor.BackColor = value;
            }
        }

        private void buttonIncreaseBPM_Click(object sender, EventArgs e)
        {
            controller.IncreaseBPM();
        }

        private void buttonDecreaseBPM_Click(object sender, EventArgs e)
        {
            controller.DecreaseBPM();
        }

        internal void DisabledStartMenuItem()
        {
            buttonStart.Enabled = false;
        }

        internal void EnabledStartMunuItem()
        {
            buttonStart.Enabled = true;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            controller.Start();
        }
    }
}