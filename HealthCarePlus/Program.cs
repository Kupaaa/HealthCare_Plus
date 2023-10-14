using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCarePlus
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new AdminDash());
            Application.Run(new Login());
            //Application.Run(new Receptionists());
            //Application.Run(new Doctors());
            //Application.Run(new Patients());
            //Application.Run(new Prescriptions());
            //Application.Run(new LabTests());
            //Application.Run(new Nurse());
            //Application.Run(new Homes());

            //Application.Run(new Rooms());
            //Application.Run(new AdminDashNew());
            //Application.Run(new PatientsNew());
            //Application.Run(new Appointment());



        }
    }
}
