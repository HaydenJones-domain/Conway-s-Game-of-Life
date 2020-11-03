using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Conway_s_Game_of_Life
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
            MasterGridCreator masterGrid = new MasterGridCreator();
            GridIterator GridIterator = new GridIterator();
            Application.Run(new Form1());
        }
    }
}
