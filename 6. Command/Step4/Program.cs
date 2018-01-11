using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step4
{
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
    public class TV
    {
        String location;
        int channel;

        public TV(String location)
        {
            this.location = location;
        }

        public void On()
        {
            Console.WriteLine(location + " TV is on");
        }

        public void Off()
        {
            Console.WriteLine(location + " TV is off");
        }

        public void SetInputChannel()
        {
            channel = 3;
            Console.WriteLine(location + " TV channel is set for DVD");
        }
    }
    public class Hottub
    {
        bool on;
        int temperature;

        public Hottub()
        {
        }

        public void On()
        {
            on = true;
        }

        public void Off()
        {
            on = false;
        }

        public void Circulate()
        {
            if (on)
            {
                Console.WriteLine("Hottub is bubbling!");
            }
        }

        public void JetsOn()
        {
            if (on)
            {
                Console.WriteLine("Hottub jets are on");
            }
        }

        public void JetsOff()
        {
            if (on)
            {
                Console.WriteLine("Hottub jets are off");
            }
        }

        public void SetTemperature(int temperature)
        {
            if (temperature > this.temperature)
            {
                Console.WriteLine("Hottub is heating to a steaming " + temperature + " degrees");
            }
            else
            {
                Console.WriteLine("Hottub is cooling to " + temperature + " degrees");
            }
            this.temperature = temperature;
        }
    }
    #endregion

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
    class StereoOnCommand : ICommand
    {
        Stereo stereo;

        public StereoOnCommand(Stereo stereo)
        {
            this.stereo = stereo;
        }

        public void Execute()
        {
            stereo.On();
        }
        public void Undo()
        {
            stereo.Off();
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

    class TVOnCommand : ICommand
    {
        TV tv;

        public TVOnCommand(TV tv)
        {
            this.tv = tv;
        }

        public void Execute()
        {
            tv.On();
            tv.SetInputChannel();
        }

        public void Undo()
        {
            tv.Off();
        }
    }
    class TVOffCommand : ICommand
    {
        TV tv;


        public TVOffCommand(TV tv)
        {
            this.tv = tv;
        }

        public void Execute()
        {
            tv.Off();
        }

        public void Undo()
        {
            tv.On();
        }
    }

    class HottubOnCommand : ICommand
    {
        Hottub hottub;

        public HottubOnCommand(Hottub hottub)
        {
            this.hottub = hottub;
        }
        public void Execute()
        {
            hottub.On();
            hottub.SetTemperature(104);
            hottub.Circulate();
        }
        public void Undo()
        {
            hottub.Off();
        }
    }
    class HottubOffCommand : ICommand
    {
        Hottub hottub;

        public HottubOffCommand(Hottub hottub)
        {
            this.hottub = hottub;
        }

        public void Execute()
        {
            hottub.SetTemperature(98);
            hottub.Off();
        }
        public void Undo()
        {
            hottub.On();
        }
    }


    class MacroCommand : ICommand
    {
        ICommand[] commands;

        public MacroCommand(ICommand[] commands)
        {
            this.commands = commands;
        }

        public void Execute()
        {
            for (int i = 0; i < commands.Length; i++)
            {
                commands[i].Execute();
            }
        }

        public void Undo()
        {
            for (int i = 0; i < commands.Length; i++)
            {
                commands[i].Undo();
            }
        }
    }
    #endregion

    class RemoteControl
    {
        ICommand[] onCommands;
        ICommand[] offCommands;
        ICommand undoCommand;

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
            stringBuff.Append("[undo] " + undoCommand + "\n");
            return stringBuff.ToString();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            RemoteControl remoteControl = new RemoteControl();

            Light light = new Light("Living Room");
            TV tv = new TV("Living Room");
            Stereo stereo = new Stereo("Living Room");
            Hottub hottub = new Hottub();

            LightOnCommand lightOn = new LightOnCommand(light);
            StereoOnCommand stereoOn = new StereoOnCommand(stereo);
            TVOnCommand tvOn = new TVOnCommand(tv);
            HottubOnCommand hottubOn = new HottubOnCommand(hottub);

            LightOffCommand lightOff = new LightOffCommand(light);
            StereoOffCommand stereoOff = new StereoOffCommand(stereo);
            TVOffCommand tvOff = new TVOffCommand(tv);
            HottubOffCommand hottubOff = new HottubOffCommand(hottub);

            ICommand[] partyOn = { lightOn, stereoOn, tvOn, hottubOn };
            ICommand[] partyOff = { lightOff, stereoOff, tvOff, hottubOff };

            MacroCommand partyOnMacro = new MacroCommand(partyOn);
            MacroCommand partyOffMacro = new MacroCommand(partyOff);

            remoteControl.SetCommand(0, partyOnMacro, partyOffMacro);

            Console.WriteLine(remoteControl);
            Console.WriteLine("--- Pushing Macro On---");
            remoteControl.OnButtonWasPushed(0);
            Console.WriteLine("--- Pushing Macro Off---");
            remoteControl.OffButtonWasPushed(0);

            Console.ReadKey();
        }
    }

}
