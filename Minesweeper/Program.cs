using Minesweeper.Properties;
using System;
using System.Threading;
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
            Application.ThreadException += new ThreadExceptionEventHandler(ShowMessage);

            var form = new FormMain();
            form.WindowState = Settings.Default.IsMaximized ? FormWindowState.Maximized : FormWindowState.Normal;

            Application.Run(form);
        }

        private static void ShowMessage(object sender, ThreadExceptionEventArgs e) =>
            MessageBox.Show(e.Exception.ToString());
    }
}
