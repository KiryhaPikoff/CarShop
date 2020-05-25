using System;
using System.Windows.Forms;

namespace CarShopStorageView
{
    static class Program
    {
        public static bool isLogged = false;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            APIClient.Connect();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var formEnter = new FormEnter();
            formEnter.ShowDialog();

            if (isLogged)
            {
                Application.Run(new FormStorages());
            }
        }
    }
}
