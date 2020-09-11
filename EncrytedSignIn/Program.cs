using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EncrytedSignIn
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

            DialogResult dialogResult = MessageBox.Show("Do you Want to Open SignUp form OR SignIn form? \n(Yes For SignUp, No For SignIn)", "???", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                Application.Run(new SignUp());
        
            }
            else if (dialogResult == DialogResult.No)
            {
             
                Application.Run(new SignIn());
            
            }
            
            }
    }
}
