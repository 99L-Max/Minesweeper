using System;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class FormDialogNewGame : Form
    {
        public FormDialogNewGame()
        {
            InitializeComponent();
        }

        public event Action<bool> PlayerChose;

        private void OnOKClick(object sender, EventArgs e)
        {
            if (_rbNewGame.Checked)
            {
                PlayerChose?.Invoke(true);
            }
            else if (_rbRestart.Checked)
            { 
                PlayerChose?.Invoke(false);
            }

            Close();
        }
    }
}
