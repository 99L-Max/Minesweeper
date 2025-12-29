using Minesweeper.Properties;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Minesweeper
{
    partial class FormSettings : Form
    {
        private readonly bool _isFirstMove;
        private readonly SettingsData _settingsData;
        private readonly ISetSettings[] _setSettings;

        private CheckBoxSettings[] _checkBoxSettings;
        private RadioButtonLevel[] _radioButtonsLevel;
        private Level _selectedLevel;

        public FormSettings(SettingsData data, bool isFirstMove, params ISetSettings[] setSettings)
        {
            InitializeComponent();

            _selectedLevel = data.Level;
            _settingsData = data;
            _isFirstMove = isFirstMove;
            _setSettings = setSettings;
        }

        public event Action<bool> LevelDataChanged;

        private void OnFormLoad(object sender, EventArgs e)
        {
            _checkBoxSettings = ControlsFactory.CreateCheckBoxSettings(_panelCheckBoxes.ClientSize.Width).ToArray();
            _radioButtonsLevel = ControlsFactory.CreateRadioButtonLevel(120, 50, _settingsData.Level);

            _panelCheckBoxes.Controls.AddRange(_checkBoxSettings);

            for (int i = 0; i < _radioButtonsLevel.Length; i++)
            {
                _panelRadioButtons.Controls.Add(_radioButtonsLevel[i]);
                _panelRadioButtons.Controls.SetChildIndex(_radioButtonsLevel[i], i);
            }

            foreach (var box in _checkBoxSettings)
            {
                box.Checked = _settingsData.GetSettings(box.Settings);
            }

            foreach (var button in _radioButtonsLevel)
            {
                button.CheckedChanged += OnLevelCheckedChanged;

                if (button.Level == Level.Special)
                    button.CheckedChanged += OnSpesialLevelCheckedChanged;
            }

            _numSpecialWidth.Value = _settingsData.SpecialMapWidth;
            _numSpecialHeight.Value = _settingsData.SpecialMapHeight;
            _numSpecialMinesCount.Value = _settingsData.SpecialMinesCount;

            _lblHeight.Text = $"Высота ({SettingsData.MapMinHeight}-{SettingsData.MapMaxHeight}):";
            _lblWidth.Text = $"Ширина ({SettingsData.MapMinWidth}-{SettingsData.MapMaxWidth}):";
            _lblMinesCount.Text = $"Число мин ({SettingsData.MinesMinCount}-{SettingsData.GetMinesMaxCount(SettingsData.MapMaxWidth * SettingsData.MapMaxHeight)}):";

            _panelSpecialLevelData.Enabled = _selectedLevel == Level.Special;
        }

        private void OnLevelCheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButtonLevel button)
                _selectedLevel = button.Level;
        }

        private void OnSpesialLevelCheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButtonLevel button)
                _panelSpecialLevelData.Enabled = button.Checked;
        }

        private void OnSpecialSizeChanged(object sender, EventArgs e)
        {
            _numSpecialMinesCount.Maximum = SettingsData.GetMinesMaxCount(_numSpecialWidth.Value * _numSpecialHeight.Value);
        }

        private void OnOKClick(object sender, EventArgs e)
        {
            var settings = _checkBoxSettings.ToDictionary(box => box.Settings, box => box.Checked);
            var isLevelChanged = _selectedLevel != _settingsData.Level;
            var isSpecialLevelDataChanged = _numSpecialWidth.Value != _settingsData.SpecialMapWidth || _numSpecialHeight.Value != _settingsData.SpecialMapHeight || _numSpecialMinesCount.Value != _settingsData.SpecialMinesCount;

            _settingsData.SetSettings(settings);

            foreach (var setSettings in _setSettings)
                setSettings.SetSettings(_settingsData);

            if (isLevelChanged || (_selectedLevel == Level.Special && isSpecialLevelDataChanged))
            {
                _settingsData.SetSpecialLevelData((int)_numSpecialWidth.Value, (int)_numSpecialHeight.Value, (int)_numSpecialMinesCount.Value);
                _settingsData.SetLevel(_selectedLevel);

                if (_isFirstMove)
                {
                    LevelDataChanged?.Invoke(false);
                }
                else if (MessageShower.ShowQuestion(Resources.SettingsChanged) == DialogResult.Yes)
                {
                    LevelDataChanged?.Invoke(true);
                }
            }

            Close();
        }
    }
}
