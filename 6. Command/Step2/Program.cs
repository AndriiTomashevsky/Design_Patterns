using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Назначение паттерна Команда - представляет запрос в виде объекта

namespace Step2
{
    // Получатели
    #region 
    class Light
    {
        String location = "";

        public Light(String location)
        {
            this.location = location;
        }
        public void On()
        {
            Console.WriteLine(location + " light is on");
        }
        public void Off()
        {
            Console.WriteLine(location + " light is off");
        }
    }
    public class GarageDoor
    {
        String location;

        public GarageDoor(String location)
        {
            this.location = location;
        }

        public void Up()
        {
            Console.WriteLine(location + " garage Door is Up");
        }

        public void Down()
        {
            Console.WriteLine(location + " garage Door is Down");
        }

        public void stop()
        {
            Console.WriteLine(location + " garage Door is Stopped");
        }

        public void lightOn()
        {
            Console.WriteLine(location + " garage light is on");
        }

        public void lightOff()
        {
            Console.WriteLine(location + " garage light is off");
        }
    }
    public class Stereo
    {
        String location;

        public Stereo(String location) { this.location = location; }
        public void On() { Console.WriteLine(location + " stereo is on"); }
        public void Off() { Console.WriteLine(location + " stereo is off"); }
        public void SetCD() { Console.WriteLine(location + " stereo is set for CD input"); }
        public void SetDVD() { Console.WriteLine(location + " stereo is set for DVD input"); }
        public void SetRadio() { Console.WriteLine(location + " stereo is set for Radio"); }

        public void SetVolume(int volume)
        {
            // code to set the volume
            // valid range: 1-11 (after all 11 is better than 10, right?)
            Console.WriteLine(location + " Stereo volume set to " + volume);
        }

    }
    public class CeilingFan
    {
        String location = "";
        int level;
        public const int HIGH = 2;
        public const int MEDIUM = 1;
        public const int LOW = 0;

        public CeilingFan(String location)
        {
            this.location = location;
        }

        public void high()
        {
            // turns the ceiling fan on to high
            level = HIGH;
            Console.WriteLine(location + " ceiling fan is on high");

        }

        public void medium()
        {
            // turns the ceiling fan on to medium
            level = MEDIUM;
            Console.WriteLine(location + " ceiling fan is on medium");
        }

        public void low()
        {
            // turns the ceiling fan on to low
            level = LOW;
            Console.WriteLine(location + " ceiling fan is on low");
        }

        public void off()
        {
            // turns the ceiling fan off
            level = 0;
            Console.WriteLine(location + " ceiling fan is off");
        }

        public int getSpeed()
        {
            return level;
        }
    }
    #endregion

    // Команды
    #region 
    interface ICommand { void Execute(); }

    class NoCommand : ICommand { public void Execute() { } }

    public class StereoOnWithCDCommand : ICommand
    {
        Stereo stereo;


        public StereoOnWithCDCommand(Stereo stereo)
        {
            this.stereo = stereo;
        }

        public void Execute()
        {
            stereo.On();
            stereo.SetCD();
            stereo.SetVolume(11);
        }
    }
    public class StereoOffCommand : ICommand
    {
        Stereo stereo;


        public StereoOffCommand(Stereo stereo)
        {
            this.stereo = stereo;
        }

        public void Execute()
        {
            stereo.Off();
        }
    }
    public class GarageDoorDownCommand : ICommand
    {
        GarageDoor garageDoor;


        public GarageDoorDownCommand(GarageDoor garageDoor)
        {
            this.garageDoor = garageDoor;
        }

        public void Execute()
        {
            garageDoor.Up();
        }
    }
    public class GarageDoorUpCommand : ICommand
    {
        GarageDoor garageDoor;


        public GarageDoorUpCommand(GarageDoor garageDoor)
        {
            this.garageDoor = garageDoor;
        }

        public void Execute()
        {
            garageDoor.Up();
        }
    }
    class LightOnCommand : ICommand
    {
        Light light;
        public LightOnCommand(Light light) { this.light = light; }

        public void Execute()
        {
            light.On();
        }
    }
    class LightOffCommand : ICommand
    {
        Light light;
        public LightOffCommand(Light light) { this.light = light; }

        public void Execute()
        {
            light.Off();
        }
    }
    class StereoOnWithCdCommand : ICommand
    {
        Stereo stereo;
        public StereoOnWithCdCommand(Stereo stereo) { this.stereo = stereo; }

        public void Execute()
        {
            stereo.On();
            stereo.SetCD();
            stereo.SetVolume(11);
        }
    }
    public class CeilingFanOffCommand : ICommand
    {
        CeilingFan ceilingFan;


        public CeilingFanOffCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
        }
        public void Execute()
        {
            ceilingFan.off();
        }
    }
    public class CeilingFanOnCommand : ICommand
    {
        CeilingFan ceilingFan;


        public CeilingFanOnCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
        }
        public void Execute()
        {
            ceilingFan.high();
        }
    }
    #endregion

    // Инициатор, официантка, ячейка пульта
    class RemoteControl
    {
        ICommand[] onCommands;
        ICommand[] offCommands;

        public RemoteControl()
        {
            onCommands = new ICommand[7];
            offCommands = new ICommand[7];

            ICommand noCommand = new NoCommand();
            for (int i = 0; i < 7; i++)
            {
                onCommands[i] = noCommand;
                offCommands[i] = noCommand;
            }
        }
        public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;
        }
        public void OnButtonWasPushed(int slot)
        {
            onCommands[slot].Execute();
        }
        public void OffButtonWasPushed(int slot)
        {
            offCommands[slot].Execute();
        }
        public override string ToString()
        {
            StringBuilder stringBuff = new StringBuilder();
            stringBuff.Append("\n------ Remote Control -------\n");
            for (int i = 0; i < onCommands.Length; i++)
            {
                stringBuff.Append("[slot " + i + "] " + onCommands[i]
                    + "    " + offCommands[i] + "\n");
            }
            return stringBuff.ToString();
        }

    }

    // Клиент
    class Program
    {
        static void Main(string[] args)
        {
            RemoteControl remoteControl = new RemoteControl();

            // Создание всех устройств
            Light livingRoomLight = new Light("Living Room");
            Light kitchenLight = new Light("Kitchen");
            CeilingFan ceilingFan = new CeilingFan("Living Room");
            GarageDoor garageDoor = new GarageDoor("");
            Stereo stereo = new Stereo("Living Room");

            // Создание команд 
            LightOnCommand livingRoomLightOn = new LightOnCommand(livingRoomLight);
            LightOffCommand livingRoomLightOff = new LightOffCommand(livingRoomLight);

            LightOnCommand kitchenLightOn = new LightOnCommand(kitchenLight);
            LightOffCommand kitchenLightOff = new LightOffCommand(kitchenLight);

            CeilingFanOnCommand ceilingFanOn = new CeilingFanOnCommand(ceilingFan);
            CeilingFanOffCommand ceilingFanOff = new CeilingFanOffCommand(ceilingFan);

            GarageDoorUpCommand garageDoorUp = new GarageDoorUpCommand(garageDoor);
            GarageDoorDownCommand garageDoorDown = new GarageDoorDownCommand(garageDoor);

            StereoOnWithCDCommand stereoOnWithCD = new StereoOnWithCDCommand(stereo);
            StereoOffCommand stereoOff = new StereoOffCommand(stereo);


            // Готовые команды связываются с ячейками пульта
            remoteControl.SetCommand(0, livingRoomLightOn, livingRoomLightOff);
            remoteControl.SetCommand(1, kitchenLightOn, kitchenLightOff);
            remoteControl.SetCommand(2, ceilingFanOn, ceilingFanOff);
            remoteControl.SetCommand(3, stereoOnWithCD, stereoOff);

            Console.WriteLine(remoteControl);

            // Перебираем все ячейки, и для каждой ячейки имитируем нажатие кнопок «вкл» и «выкл». 
            remoteControl.OnButtonWasPushed(0);
            remoteControl.OffButtonWasPushed(0);
            remoteControl.OnButtonWasPushed(1);
            remoteControl.OffButtonWasPushed(1);
            remoteControl.OnButtonWasPushed(2);
            remoteControl.OffButtonWasPushed(2);
            remoteControl.OnButtonWasPushed(3);
            remoteControl.OffButtonWasPushed(3);

            Console.ReadKey();
        }
    }
}
