using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PPSDPart2
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

            //Called prior to showing the user window
            string message = "";
            if (init(out message))
                Application.Run(new frmLogin());
            else
            {
                MessageBox.Show("Error: " + message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        static bool init(out string message)
        {
            message = "Failed to initialise database connection";
            return true;
        }
    }
}
