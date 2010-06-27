using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAMPCE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new f_main(args));
        }
    }
}
