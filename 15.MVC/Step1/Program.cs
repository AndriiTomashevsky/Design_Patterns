using System;
using System.Windows.Forms;

namespace Step1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IBeatModel model = new BeatModel();
            IController controller = new BeatController(model);
        }
    }
}
