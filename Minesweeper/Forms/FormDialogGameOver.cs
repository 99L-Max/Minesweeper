using System;
using System.Windows.Forms;

namespace Minesweeper
{
    enum Decision { NewGame, Restart, Exit }

    partial class FormDialogGameOver : Form
    {
        private Decision _decision = Decision.Exit;

        public Action<Decision> PlayerChose;

        public FormDialogGameOver(Level level, bool isWin, int seconds, StatisticalData data)
        {
            InitializeComponent();

            _btnNewGame.Tag = Decision.NewGame;
            _btnRestart.Tag = Decision.Restart;
            _btnExit.Tag = Decision.Exit;

            if (isWin)
            {
                Text = "Игра выиграна";
                _lblMessage.Text = "Поздравляем, Вы выиграли!";

                if (seconds == data.GetBestTime(level))
                    _lblMessage.Text += "\n\nВы показали самое лучшее время для данного уровня сложности!";

                _btnRestart.Visible = false;
            }
            else
            {
                Text = "Игра проиграна";
                _lblMessage.Text = "К сожалению, Вы проиграли. В следующий раз повезёт больше!";
            }

            if (level != Level.Special)
            {
                _lblData1.Text = $"Время: {seconds} сек.\n\n{data.GetVictoriesData(level)}";
                _lblData2.Text =
                    $"Дата: {DateTime.Now:d}\n\n\n\n" +
                    $"Процент: {data.GetPercentVictories(level)}%";
            }
            else
            {
                _lblData1.Visible = _lblData2.Visible = false;
            }
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                _decision = (Decision)btn.Tag;
                Close();
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e) => 
            PlayerChose?.Invoke(_decision);
    }
}
