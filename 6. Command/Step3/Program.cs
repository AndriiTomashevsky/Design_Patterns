using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Нужно реализовать поддержку отмены операций на пульте.Допустим, свет в гостиной выключен, а вы
// нажимаете на пульте кнопку включения.Разумеется, свет включается. Если теперь нажать кнопку отмены, 
// то последняя операция отменяется — свет выключается. 

namespace Step3
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
        public const int HIGH = 3;
        public const int MEDIUM = 2;
        public const int LOW = 1;
        public const int OFF = 0;
        string location;
        int speed;

        public CeilingFan(string location)
        {
            this.location = location;
            speed = OFF;
        }

        public void High()
        {
            speed = HIGH;
            Console.WriteLine(location + " ceiling fan is on high");
        }

        public void Medium()
        {
            speed = MEDIUM;
            Console.WriteLine(location + " ceiling fan is on medium");
        }

        public void Low()
        {
            speed = LOW;
            Console.WriteLine(location + " ceiling fan is on low");
        }

        public void Off()
        {
            speed = OFF;
            Console.WriteLine(location + " ceiling fan is off");
        }

        public int GetSpeed()
        {
            return speed;
        }
    }
    #endregion

    // Команды
    #region 
    interface ICommand { void Execute(); void Undo(); }

    class NoCommand : ICommand
    {
        public void Execute() { }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }

    class StereoOnWithCDCommand : ICommand
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

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
    class StereoOffCommand : ICommand
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

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
    class GarageDoorDownCommand : ICommand
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

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
    class GarageDoorUpCommand : ICommand
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

        public void Undo()
        {
            throw new NotImplementedException();
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

        public void Undo()
        {
            light.Off();
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

        public void Undo()
        {
            light.On();
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

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }

    class CeilingFanOffCommand : ICommand
    {
        CeilingFan ceilingFan;
        int prevSpeed;

        public CeilingFanOffCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
        }
        public void Execute()
        {
            prevSpeed = ceilingFan.GetSpeed();
            ceilingFan.Off();
        }

        public void Undo()
        {
            if (prevSpeed == CeilingFan.HIGH)
            {
                ceilingFan.High();
            }
            else if (prevSpeed == CeilingFan.MEDIUM)
            {
                ceilingFan.Medium();
            }
            else if (prevSpeed == CeilingFan.LOW)
            {
                ceilingFan.Low();
            }
            else if (prevSpeed == CeilingFan.OFF)
            {
                ceilingFan.Off();
            }
        }
    }
    class CeilingFanLowCommand : ICommand
    {
        CeilingFan ceilingFan;
        int prevSpeed;

        public CeilingFanLowCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
        }
        public void Execute()
        {
            prevSpeed = ceilingFan.GetSpeed();
            ceilingFan.Low();
        }

        public void Undo()
        {
            if (prevSpeed == CeilingFan.HIGH)
            {
                ceilingFan.High();
            }
            else if (prevSpeed == CeilingFan.MEDIUM)
            {
                ceilingFan.Medium();
            }
            else if (prevSpeed == CeilingFan.LOW)
            {
                ceilingFan.Low();
            }
            else if (prevSpeed == CeilingFan.OFF)
            {
                ceilingFan.Off();
            }
        }
    }
    class CeilingFanHighCommand : ICommand
    {
        CeilingFan ceilingFan;
        int prevSpeed;

        public CeilingFanHighCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
        }

        public void Execute()
        {
            prevSpeed = ceilingFan.GetSpeed();
            ceilingFan.High();
        }

        public void Undo()
        {
            if (prevSpeed == CeilingFan.HIGH)
            {
                ceilingFan.High();
            }
            else if (prevSpeed == CeilingFan.MEDIUM)
            {
                ceilingFan.Medium();
            }
            else if (prevSpeed == CeilingFan.LOW)
            {
                ceilingFan.Low();
            }
            else if (prevSpeed == CeilingFan.OFF)
            {
                ceilingFan.Off();
            }
        }
    }
    class CeilingFanMediumCommand : ICommand
    {
        private CeilingFan ceilingFan;
        int prevSpeed;

        public CeilingFanMediumCommand(CeilingFan ceilingFan)
        {
            prevSpeed = ceilingFan.GetSpeed();
            this.ceilingFan = ceilingFan;
        }

        public void Execute()
        {
            prevSpeed = ceilingFan.GetSpeed();
            ceilingFan.Medium();
        }

        public void Undo()
        {
            if (prevSpeed == CeilingFan.HIGH)
            {
                ceilingFan.High();
            }
            else if (prevSpeed == CeilingFan.MEDIUM)
            {
                ceilingFan.Medium();
            }
            else if (prevSpeed == CeilingFan.LOW)
            {
                ceilingFan.Low();
            }
            else if (prevSpeed == CeilingFan.OFF)
            {
                ceilingFan.Off();
            }
        }
    }


    #endregion

    // Инициатор, официантка, ячейка пульта
    class RemoteControlWithUndo
    {
        ICommand[] onCommands;
        ICommand[] offCommands;
        ICommand undoCommand;

        public RemoteControlWithUndo()
        {
            onCommands = new ICommand[7];
            offCommands = new ICommand[7];

            ICommand noCommand = new NoCommand();
            for (int i = 0; i < 7; i++)
            {
                onCommands[i] = noCommand;
                offCommands[i] = noCommand;
            }
            undoCommand = noCommand;
        }
        public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;
        }
        public void OnButtonWasPushed(int slot)
        {
            onCommands[slot].Execute();
            undoCommand = onCommands[slot];
        }
        public void OffButtonWasPushed(int slot)
        {
            offCommands[slot].Execute();
            undoCommand = offCommands[slot];
        }
        public void UndoButtonWasPushed()
        {
            undoCommand.Undo();
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
            RemoteControlWithUndo remoteControl = new RemoteControlWithUndo();

            Light livingRoomLight = new Light("Living Room");

            LightOnCommand livingRoomLightOn = new LightOnCommand(livingRoomLight);
            LightOffCommand livingRoomLightOff = new LightOffCommand(livingRoomLight);


            remoteControl.SetCommand(0, livingRoomLightOn, livingRoomLightOff);

            remoteControl.OnButtonWasPushed(0);
            remoteControl.OffButtonWasPushed(0);
            Console.WriteLine(remoteControl);
            remoteControl.UndoButtonWasPushed();
            remoteControl.OffButtonWasPushed(0);
            remoteControl.OnButtonWasPushed(0);
            Console.WriteLine(remoteControl);
            remoteControl.UndoButtonWasPushed();

            CeilingFan ceilingFan = new CeilingFan("Living Room");

            CeilingFanMediumCommand ceilingFanMedium = new CeilingFanMediumCommand(ceilingFan);

            CeilingFanHighCommand ceilingFanHigh = new CeilingFanHighCommand(ceilingFan);

            CeilingFanOffCommand ceilingFanOff = new CeilingFanOffCommand(ceilingFan);


            remoteControl.SetCommand(0, ceilingFanMedium, ceilingFanOff);
            remoteControl.SetCommand(1, ceilingFanHigh, ceilingFanOff);

            remoteControl.OnButtonWasPushed(0);
            remoteControl.OffButtonWasPushed(0);
            Console.WriteLine(remoteControl);
            remoteControl.UndoButtonWasPushed();

            remoteControl.OnButtonWasPushed(1);
            Console.WriteLine(remoteControl);
            remoteControl.UndoButtonWasPushed();


            Console.ReadKey();
        }
    }

}
