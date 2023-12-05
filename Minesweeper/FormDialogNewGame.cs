using System.Windows.Forms;

namespace Minesweeper
{
    public partial class FormDialogNewGame : Form
    {
        public delegate void EventPlayerChose(bool isNewGame);
        public event EventPlayerChose PlayerChose;

        public FormDialogNewGame()
        {
            InitializeComponent();
            radioButtonContinueGame.Checked = true;
        }

        private void ButtonOK_Click(object sender, System.EventArgs e)
        {
            if (radioButtonNewGame.Checked)
                PlayerChose.Invoke(true);
            else if(radioButtonRestart.Checked)
                PlayerChose.Invoke(false);

            Close();
        }
    }
}
