using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Minesweeper
{
    partial class Statistics : Form
    {
        private static readonly StatsData stats;
        private static readonly string pathSave;

        public static int? GetBestTime(Level level) => stats.BestTime[level];
        public static int GetCountGames(Level level) => stats.Games[level];
        public static int GetVictories(Level level) => stats.Victories[level];

        static Statistics()
        {
            stats = new StatsData();
            pathSave = FormMain.PathLocalAppData + @"\Statistics.json";

            try
            {
                string json = File.ReadAllText(pathSave);
                stats = JsonConvert.DeserializeObject<StatsData>(json);
            }
            catch (Exception)
            {
                stats.Clear();
            }
        }

        public Statistics()
        {
            InitializeComponent();
            Text = $"Статистика игры \"Сапёр\" - {Environment.UserName}";
            buttonReset.Enabled = !stats.IsEmpty;
            listBoxLevel.SelectedIndex = 0;
        }

        private static void SaveFile()
        {
            string data = JsonConvert.SerializeObject(stats);
            File.WriteAllText(pathSave, data);
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Обнулить всю статистику?", "Сброс статистики", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                buttonReset.Enabled = false;
                stats.Clear();
                SaveFile();
                ListBoxLevel_SelectedIndexChanged(null, null);
            }
        }

        private void ListBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Level level = (Level)listBoxLevel.SelectedIndex;
            int percent = stats.Games[level] == 0 ? 0 : stats.Victories[level] * 100 / stats.Games[level];
            var newLine = Environment.NewLine;

            textBoxData.Text =
                $"Проведено игр: {stats.Games[level]}{newLine}" +
                $"Выиграно: {stats.Victories[level]}{newLine}" +
                $"Процент выигрышей: {percent}%{newLine}" +
                $"Выигрышей подряд: {stats.MaxSeriesVictories[level]}{newLine}" +
                $"Проигрышей подряд: {stats.MaxSeriesLosses[level]}{newLine}" +
                $"В текущем сеансе: {stats.Session[level]}";

            textBoxRecords.Text = string.Join($"{newLine}", stats.Records[level]);
        }

        public static void WriteStatistics(Level level, bool isWin, int seconds = 0)
        {
            if (level == Level.Special)
                return;

            stats.IsEmpty = false;

            stats.Games[level]++;
            if (isWin)
            {
                stats.Victories[level]++;
                stats.Session[level]++;

                stats.SeriesVictories[level]++;
                stats.SeriesLosses[level] = 0;

                if (stats.MaxSeriesVictories[level] < stats.SeriesVictories[level])
                    stats.MaxSeriesVictories[level] = stats.SeriesVictories[level];

                if (stats.BestTime[level] == null || seconds < stats.BestTime[level])
                    stats.BestTime[level] = seconds;

                //Запоминать только 5 лучших результатов
                stats.Records[level].Add($"{seconds}\t{DateTime.Now:d}");
                stats.Records[level] = stats.Records[level].OrderBy(x => x).Take(5).ToList();
            }
            else
            {
                stats.Session[level]--;

                stats.SeriesLosses[level]++;
                stats.SeriesVictories[level] = 0;

                if (stats.MaxSeriesLosses[level] < stats.SeriesLosses[level])
                    stats.MaxSeriesLosses[level] = stats.SeriesLosses[level];
            }

            SaveFile();
        }
    }
}
