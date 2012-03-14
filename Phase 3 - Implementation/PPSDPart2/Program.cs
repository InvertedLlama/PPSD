using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using PPSDPart2.Objects;

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

            //Attempt to init. If this fails show the user an error message
            if (init(out message))
                Application.Run(new frmLogin());
            else
            {
                MessageBox.Show("Error: " + message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        //Opens connection to database, pulls initial data.
        static bool init(out string message)
        {
            message = "Failed to initialise database connection";
            return true;
        }
    }
}
