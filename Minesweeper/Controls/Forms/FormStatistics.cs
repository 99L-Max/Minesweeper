using Minesweeper.Properties;
using System;
using System.Windows.Forms;

namespace Minesweeper
{
    partial class FormStatistics : Form
    {
        private readonly StatisticsData _data;

        public FormStatistics(StatisticsData data)
        {
            InitializeComponent();
            Text = $"Статистика игры \"Сапёр\" - {Environment.UserName}";

            foreach (var levelData in SettingsData.LevelData)
                _lbxLevel.Items.Add(levelData.Value.Title);

            _data = data;
            _btnReset.Enabled = _data.IsEmpty == false;
            _lbxLevel.SelectedIndex = 0;
        }

        private void OnResetClick(object sender, EventArgs e)
        {
            if (MessageShower.ShowQuestion(Resources.ResettingStatistics) == DialogResult.Yes)
            {
                _btnReset.Enabled = false;
                _data.Clear();

                OnLevelChanged(null, null);
            }
        }

        private void OnLevelChanged(object sender, EventArgs e)
        {
            var level = (Level)_lbxLevel.SelectedIndex;

            _txtData.Text = _data.GetData(level);
            _txtRecords.Text = _data.GetRecords(level);
        }
    }
}
