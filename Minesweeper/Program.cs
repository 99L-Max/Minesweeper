using Minesweeper.Properties;
using System;
using System.Windows.Forms;

namespace Minesweeper
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormMain form = new FormMain
            {
                WindowState = Settings.Default.IsMaximized ? FormWindowState.Maximized : FormWindowState.Normal
            };

            Application.Run(form);
        }
    }
}
