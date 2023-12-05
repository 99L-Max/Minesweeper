using System;
using System.Windows.Forms;

namespace Minesweeper
{
    enum Desicion
    {
        NewGame,
        Restart,
        Exit
    }
    partial class FormDialogGameOver : Form
    {
        private Desicion desicion = Desicion.Exit;

        public delegate void EventPlayerChose(Desicion des);
        public event EventPlayerChose PlayerChose;

        public FormDialogGameOver(Level level, bool isWin, int seconds)
        {
            InitializeComponent();

            if (isWin)
            {
                Text = "Игра выиграна";
                labelMessage.Text = "Поздравляем, Вы выиграли!";

                if (level != Level.Special && seconds == Statistics.GetBestTime(level))
                    labelMessage.Text += "\n\nВы показали самое лучшее время для данного уровня сложности!";

                buttonRestart.Visible = false;
            }
            else
            {
                Text = "Игра проиграна";
                labelMessage.Text = "К сожалению, Вы проиграли. В следующий раз повезёт больше!";
                buttonRestart.Click += (s, e) => { desicion = Desicion.Restart; Close(); };
            }

            if (level != Level.Special)
            {
                labelData1.Text = $"Время: {seconds} сек.\n\n";

                if (Statistics.GetBestTime(level) != null)
                    labelData1.Text += $"Лучшее время: {Statistics.GetBestTime(level)} сек.";

                labelData1.Text +=
                    $"\n\n" +
                    $"Проведено игр: {Statistics.GetCountGames(level)}\n\n" +
                    $"Выиграно: {Statistics.GetVictories(level)}";

                labelData2.Text =
                    $"Дата: {DateTime.Now:d}\n\n\n\n" +
                    $"Процент: {100 * Statistics.GetVictories(level) / Statistics.GetCountGames(level)}%";
            }
            else
            {
                labelData1.Visible = labelData2.Visible = false;
            }

            buttonNewGame.Click += (s, e) => { desicion = Desicion.NewGame; Close(); };
            buttonExit.Click += (s, e) => { desicion = Desicion.Exit; Close(); };

            FormClosing += (s, e) => PlayerChose.Invoke(desicion);
        }
    }
}
