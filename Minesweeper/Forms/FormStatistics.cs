using System;
using System.Windows.Forms;

namespace Minesweeper
{
    partial class FormStatistics : Form
    {
        private readonly StatisticalData _data;

        public FormStatistics(StatisticalData data)
        {
            InitializeComponent();
            Text = $"Статистика игры \"Сапёр\" - {Environment.UserName}";

            foreach (var item in SettingsData.DictionaryLevelTitles)
                if (item.Key != Level.Special)
                    _lbxLevel.Items.Add(item.Value);

            _data = data;
            _btnReset.Enabled = !_data.IsEmpty;
            _lbxLevel.SelectedIndex = 0;
        }

        private void OnResetClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Обнулить всю статистику?", "Сброс статистики", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
