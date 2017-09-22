using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Year_Project_Application
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartMenu());
            //Application.Run(new ModuleTimetableGeneration());
            //Application.Run(new TimetableLab2());
            //Application.Run(new TimetableLab1());
            //Application.Run(new MapLab2());
        }
    }
}
