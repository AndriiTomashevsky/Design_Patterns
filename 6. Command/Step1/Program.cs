using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step1
{
    interface ICommand{ void Execute(); }

    // Получатель
    class Light { public void On() { Console.WriteLine("Light is On"); } }
    class GarageDoor { public void Up() { Console.WriteLine("Garage door is open"); } }

    // Команда - Инкапсулированный запрос
    class LightOnCommand : ICommand
    {
        Light light;
        public LightOnCommand(Light light) { this.light = light; }

        public void Execute()                      // OrderUp()
        {
            light.On();
        }
    }

    // Команда
    class GarageDoorOpenCommand : ICommand
    {
        GarageDoor garageDoor;

        public GarageDoorOpenCommand(GarageDoor garageDoor)  { this.garageDoor = garageDoor; }

        public void Execute()
        {
            garageDoor.Up();
        }
    }

    // Инициатор (Официантка, ячейка пульта)
    class SimpleRemoteControl
    {
        ICommand slot;

        public void SetCommand(ICommand command)
        {
            slot = command;
        }
        public void ButtonWasPressed()
        {
            slot.Execute();
        }
    }
    // Клиент
    class Program
    {
        static void Main(string[] args)
        {
            SimpleRemoteControl remote = new SimpleRemoteControl();                     // Инициатор (Официантка)

            Light light = new Light();                                                   // Получатель (Повар)  
            LightOnCommand lightOn = new LightOnCommand(light);                         // Команда (Заказ)
            
            remote.SetCommand(lightOn);
            remote.ButtonWasPressed();

            GarageDoor garageDoor = new GarageDoor();
            GarageDoorOpenCommand garageOpen = new GarageDoorOpenCommand(garageDoor);
            remote.SetCommand(garageOpen);
            remote.ButtonWasPressed();

            Console.ReadKey();
        }
    }
}
