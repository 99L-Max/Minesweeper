using System;
using System.Windows.Forms;

namespace Minesweeper
{
    partial class FormDialogGameOver : Form
    {
        private DialogDecision _decision = DialogDecision.Exit;

        public FormDialogGameOver(Level level, bool isWin, int seconds, StatisticsData data)
        {
            InitializeComponent();

            _btnNewGame.Tag = DialogDecision.NewGame;
            _btnRestart.Tag = DialogDecision.Restart;
            _btnExit.Tag = DialogDecision.Exit;

            if (isWin)
            {
                Text = "Игра выиграна";
                _lblMessage.Text = "Поздравляем, Вы выиграли!";

                if (seconds == data.GetBestTime(level))
                    _lblMessage.Text += "\n\nВы показали самое лучшее время для данного уровня сложности!";
            }
            else
            {
                Text = "Игра проиграна";
                _lblMessage.Text = "К сожалению, Вы проиграли. В следующий раз повезёт больше!";
            }

            if (data.IsContainsLevel(level))
            {
                _lblData1.Text = $"Время: {seconds} сек.\n\n{data.GetVictoriesData(level)}";
                _lblData2.Text = $"Дата: {DateTime.Now:d}\n\n\n\nПроцент: {data.GetPercentVictories(level)}%";
            }

            _btnRestart.Visible = isWin == false;
            _lblData1.Visible = _lblData2.Visible = data.IsContainsLevel(level);
        }

        public event Action<DialogDecision> PlayerChose;

        private void OnButtonClick(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                _decision = (DialogDecision)button.Tag;
                Close();
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            PlayerChose?.Invoke(_decision);
        }
    }
}
