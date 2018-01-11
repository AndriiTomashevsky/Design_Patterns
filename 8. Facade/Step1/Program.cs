using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Step1
{
    // Facade
    class HomeTheaterFacade
    {
        Amplifier amp;
        Tuner tuner;
        DvdPlayer dvd;
        CdPlayer cd;
        Projector projector;
        TheaterLights lights;
        Screen screen;
        PopcornPopper popper;

        public HomeTheaterFacade(Amplifier amp,
                     Tuner tuner,
                     DvdPlayer dvd,
                     CdPlayer cd,
                     Projector projector,
                     Screen screen,
                     TheaterLights lights,
                     PopcornPopper popper)
        {
            this.amp = amp;
            this.tuner = tuner;
            this.dvd = dvd;
            this.cd = cd;
            this.projector = projector;
            this.screen = screen;
            this.lights = lights;
            this.popper = popper;
        }
        public void WatchMovie(String movie)
        {
            Console.WriteLine("Get ready to watch a movie...");
            popper.On();
            popper.Pop();
            lights.Dim(10);
            screen.Down();
            projector.On();
            projector.WideScreenMode();
            amp.On();
            amp.SetDvd(dvd);
            amp.SetSurroundSound();
            amp.SetVolume(5);
            dvd.On();
            dvd.Play(movie);
        }
        public void EndMovie()
        {
            Console.WriteLine("Shutting movie theater down...");
            popper.Off();
            lights.On();
            screen.Up();
            projector.Off();
            amp.Off();
            dvd.Stop();
            dvd.Eject();
            dvd.Off();
        }
    }
    // Классы подсистемы
    #region 
    class Screen
    {
        String description;

        public Screen(String description)
        {
            this.description = description;
        }

        public void Up()
        {
            Console.WriteLine(description + " going up");
        }

        public void Down()
        {
            Console.WriteLine(description + " going down");
        }

        public override string ToString()
        {
            return description;
        }
    }
    class PopcornPopper
    {
        String description;

        public PopcornPopper(String description)
        {
            this.description = description;
        }

        public void On()
        {
            Console.WriteLine(description + " on");
        }

        public void Off()
        {
            Console.WriteLine(description + " off");
        }

        public void Pop()
        {
            Console.WriteLine(description + " popping popcorn!");
        }
        public override String ToString()
        {
            return description;
        }

    }
    class TheaterLights
    {
        String description;

        public TheaterLights(String description)
        {
            this.description = description;
        }

        public void On()
        {
            Console.WriteLine(description + " on");
        }

        public void Off()
        {
            Console.WriteLine(description + " off");
        }

        public void Dim(int level)
        {
            Console.WriteLine(description + " dimming to " + level + "%");
        }

        public override String ToString()
        {
            return description;
        }
    }
    class CdPlayer
    {
        String description;
        int currentTrack;
        Amplifier amplifier;
        String title;

        public CdPlayer(String description, Amplifier amplifier)
        {
            this.description = description;
            this.amplifier = amplifier;
        }

        public void On()
        {
            Console.WriteLine(description + " on");
        }

        public void Off()
        {
            Console.WriteLine(description + " off");
        }

        public void Eject()
        {
            title = null;
            Console.WriteLine(description + " eject");
        }

        public void Play(String title)
        {
            this.title = title;
            currentTrack = 0;
            Console.WriteLine(description + " playing \"" + title + "\"");
        }

        public void Play(int track)
        {
            if (title == null)
            {
                Console.WriteLine(description + " can't play track " + currentTrack + ", no cd inserted");

            }
            else
            {
                currentTrack = track;
                Console.WriteLine(description + " playing track " + currentTrack);
            }
        }

        public void Stop()
        {
            currentTrack = 0;
            Console.WriteLine(description + " stopped");
        }

        public void Pause()
        {
            Console.WriteLine(description + " paused \"" + title + "\"");
        }

        public override String ToString()
        {
            return description;
        }
    }
    class Projector
    {
        String description;
        DvdPlayer dvdPlayer;

        public Projector(String description, DvdPlayer dvdPlayer)
        {
            this.description = description;
            this.dvdPlayer = dvdPlayer;
        }

        public void On()
        {
            Console.WriteLine(description + " on");
        }

        public void Off()
        {
            Console.WriteLine(description + " off");
        }

        public void WideScreenMode()
        {
            Console.WriteLine(description + " in widescreen mode (16x9 aspect ratio)");
        }

        public void TvMode()
        {
            Console.WriteLine(description + " in tv mode (4x3 aspect ratio)");
        }

        public override String ToString()
        {
            return description;
        }

    }
    class DvdPlayer
    {
        String description;
        int currentTrack;
        Amplifier amplifier;
        String movie;

        public DvdPlayer(String description, Amplifier amplifier)
        {
            this.description = description;
            this.amplifier = amplifier;
        }

        public void On()
        {
            Console.WriteLine(description + " on");
        }

        public void Off()
        {
            Console.WriteLine(description + " off");
        }

        public void Eject()
        {
            movie = null;
            Console.WriteLine(description + " eject");
        }

        public void Play(String movie)
        {
            this.movie = movie;
            currentTrack = 0;
            Console.WriteLine(description + " playing \"" + movie + "\"");
        }

        public void play(int track)
        {
            if (movie == null)
            {
                Console.WriteLine(description + " can't play track " + track + " no dvd inserted");
            }
            else
            {
                currentTrack = track;
                Console.WriteLine(description + " playing track " + currentTrack + " of \"" + movie + "\"");
            }
        }

        public void Stop()
        {
            currentTrack = 0;
            Console.WriteLine(description + " stopped \"" + movie + "\"");
        }

        public void Pause()
        {
            Console.WriteLine(description + " paused \"" + movie + "\"");
        }

        public void SetTwoChannelAudio()
        {
            Console.WriteLine(description + " set two channel audio");
        }

        public void SetSurroundAudio()
        {
            Console.WriteLine(description + " set surround audio");
        }

        public override String ToString()
        {
            return description;
        }

    }
    class Tuner
    {
        private string v;
        private Amplifier amp;

        public Tuner(string v, Amplifier amp)
        {
            this.v = v;
            this.amp = amp;
        }
    }
    class Amplifier
    {
        String description;
        Tuner tuner;
        DvdPlayer dvd;
        CdPlayer cd;

        public Amplifier(String description)
        {
            this.description = description;
        }

        public void On()
        {
            Console.WriteLine(description + " on");
        }

        public void Off()
        {
            Console.WriteLine(description + " off");
        }

        public void SetStereoSound()
        {
            Console.WriteLine(description + " stereo mode on");
        }

        public void SetSurroundSound()
        {
            Console.WriteLine(description + " surround sound on (5 speakers, 1 subwoofer)");
        }

        public void SetVolume(int level)
        {
            Console.WriteLine(description + " setting volume to " + level);
        }

        public void SetTuner(Tuner tuner)
        {
            Console.WriteLine(description + " setting tuner to " + dvd);
            this.tuner = tuner;
        }

        public void SetDvd(DvdPlayer dvd)
        {
            Console.WriteLine(description + " setting DVD player to " + dvd);
            this.dvd = dvd;
        }

        public void SetCd(CdPlayer cd)
        {
            Console.WriteLine(description + " setting CD player to " + cd);
            this.cd = cd;
        }
        public override String ToString()
        {
            return description;
        }
    }
    #endregion

    // Клиент
    class Program
    {
        static void Main(string[] args)
        {
            // Компоненты создаются прямо в ходе тестирования. Обычно клиент получает фасад, а не создает его
            Amplifier amp = new Amplifier("Top-O-Line Amplifier");
            Tuner tuner = new Tuner("Top-O-Line AM/FM Tuner", amp);
            DvdPlayer dvd = new DvdPlayer("Top-O-Line DVD Player", amp);
            CdPlayer cd = new CdPlayer("Top-O-Line CD Player", amp);
            Projector projector = new Projector("Top-O-Line Projector", dvd);
            TheaterLights lights = new TheaterLights("Theater Ceiling Lights");
            Screen screen = new Screen("Theater Screen");
            PopcornPopper popper = new PopcornPopper("Popcorn Popper");

            HomeTheaterFacade homeTheater = new HomeTheaterFacade(amp, tuner, dvd, cd, projector, screen, lights, popper);

            homeTheater.WatchMovie("Raiders of the Lost Ark");
            homeTheater.EndMovie();

            Console.ReadKey();
        }
    }
}
