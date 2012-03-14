using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using PPSDPart2.Objects;

namespace PPSDPart2
{
    static class Program
    {
        static Database programDatabase = new Database("SERVER=cfe.no-ip.org;" +
                                                       "DATABASE=PPSD;" +
                                                       "UID=ppsdgroup;" +
                                                       "PASSWORD=ppsdgroup;" +
                                                       "PORT=7774;");

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
            if (init(ref programDatabase, out message))
                Application.Run(new frmLogin());
            else
            {
                MessageBox.Show("Error: " + message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        //Opens connection to database, pulls initial data.
        static bool init(ref Database db, out string message)
        {
            message = "Unknown Error";
                      
            
                          
            //Attempt to establish a connection to the database
            if (!db.initalise(ref message))
            {               
                return false;
            }

            DatabaseTable dt = programDatabase.runQuery("SELECT * FROM USER_TEMP");

            Console.WriteLine(dt.ToString());
                       
            return true;
        }
    }
}
