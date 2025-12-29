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
            GameDirectory.CreateSaveDirectory();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += new ThreadExceptionEventHandler(ShowMessage);
            Application.Run(new FormMain());
        }

        private static void ShowMessage(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString());
        }
    }
}
