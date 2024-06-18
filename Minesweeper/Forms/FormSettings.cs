using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Minesweeper
{
    partial class FormSettings : Form
    {
        private readonly bool _isFirstMove;
        private readonly SettingsData _settingsData;

        private Level _selectedLevel;

        public bool IsLevelDataChanged { get; private set; } = false;

        public Action<bool> SettingsChanged;

        public FormSettings(SettingsData data, bool isFirstMove)
        {
            InitializeComponent();

            _settingsData = data;
            _isFirstMove = isFirstMove;

            var radioButtons = new Dictionary<Level, RadioButton>()
            {
                { Level.Easy, _rbEasy },
                { Level.Medium, _rbMedium },
                { Level.Hard, _rbHard },
                { Level.Special, _rbSpecial }
            };

            foreach (var key in radioButtons.Keys)
            { 
                radioButtons[key].Tag = key;
                radioButtons[key].Text = SettingsData.GetLevelDescription(key);
            }    

            radioButtons[_settingsData.Level].Checked = true;

            _numSpecialWidth.Minimum = SettingsData.MinWidthMap;
            _numSpecialHeight.Minimum = SettingsData.MinHeightMap;
            _numSpecialCountMines.Minimum = SettingsData.MinCountMines;

            _numSpecialWidth.Maximum = SettingsData.MaxWidthMap;
            _numSpecialHeight.Maximum = SettingsData.MaxHeightMap;

            _numSpecialWidth.Value = _settingsData.SpecialWidthMap;
            _numSpecialHeight.Value = _settingsData.SpecialHeightMap;
            _numSpecialCountMines.Value = _settingsData.SpecialCountMines;

            _lblHeight.Text = $"Высота ({SettingsData.MinHeightMap}-{SettingsData.MaxHeightMap}):";
            _lblWidth.Text = $"Ширина ({SettingsData.MinWidthMap}-{SettingsData.MaxWidthMap}):";
            _lblCountMines.Text = $"Число мин ({SettingsData.MinCountMines}-{SettingsData.MaxCountMines(SettingsData.MaxWidthMap * SettingsData.MaxHeightMap)}):";

            _chbShowAnimation.Tag = GameSettings.IsShowAnimation;
            _chbPlaySounds.Tag = GameSettings.IsPlaySounds;
            _chbContinueSavedGame.Tag = GameSettings.IsContinueSavedGame;
            _chbSaveGameExiting.Tag = GameSettings.IsSaveGameExiting;
            _chbShowQuestionMarks.Tag = GameSettings.IsShowQuestionMarks;

            foreach (Control ctrl in Controls)
                if (ctrl is CheckBox box)
                {
                    box.Checked = _settingsData.GetSettings((GameSettings)box.Tag);
                    box.CheckedChanged += OnCheckBoxCheckedChanged;
                }
        }

        private void OnLevelChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                if (radioButton.Name == _rbSpecial.Name)
                {
                    var enabled = _rbSpecial.Checked;

                    _numSpecialHeight.Enabled = enabled;
                    _numSpecialWidth.Enabled = enabled;
                    _numSpecialCountMines.Enabled = enabled;
                }

                _selectedLevel = (Level)radioButton.Tag;
            }
        }

        private void OnSpecialSizeChanged(object sender, EventArgs e) =>
            _numSpecialCountMines.Maximum = SettingsData.MaxCountMines(_numSpecialWidth.Value * _numSpecialHeight.Value);

        private void OnCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox box)
                _settingsData.SetSettings((GameSettings)box.Tag, box.Checked);
        }

        private void OnOKClick(object sender, EventArgs e)
        {
            if (
                _selectedLevel != _settingsData.Level ||
                _numSpecialWidth.Value != _settingsData.SpecialWidthMap ||
                _numSpecialHeight.Value != _settingsData.SpecialHeightMap ||
                _numSpecialCountMines.Value != _settingsData.SpecialCountMines
                )
            {
                _settingsData.SetMapData(_selectedLevel, (int)_numSpecialWidth.Value, (int)_numSpecialHeight.Value, (int)_numSpecialCountMines.Value);

                if (_isFirstMove)
                {
                    SettingsChanged?.Invoke(false);
                }
                else
                {
                    var dr = MessageBox.Show(
                        "Эти параметры нельзя применить к текущей игре.\n" +
                        "Новые параметры будут применены к следующей игре.\n" +
                        "Завершение игры сейчас будет засчитано как поражение\n" +
                        "Завершить текущую игру и начать новую?",
                        "Изменение настроек игры",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );

                    if (dr == DialogResult.Yes)
                        SettingsChanged?.Invoke(true);
                }
            }

            Close();
        }
    }
}
