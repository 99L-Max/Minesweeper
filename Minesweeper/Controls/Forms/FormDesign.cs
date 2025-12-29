using Minesweeper.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Minesweeper
{
    partial class FormDesign : Form
    {
        private readonly Image _flag;
        private readonly Dictionary<Theme, ButtonTheme> _themesButtons;
        private readonly SettingsData _settingsData;
        private readonly ISetTheme[] _designs;

        private Theme _selectedTheme;

        public FormDesign(SettingsData data, params ISetTheme[] designs)
        {
            InitializeComponent();

            _settingsData = data;
            _designs = designs;
            _chbRandomTheme.Checked = data.IsRandomTheme;

            _flag = ResourceImage.CutImageByEnum(Resources.Marks, CellMark.Flag);
            _themesButtons = ControlsFactory.CreateThemeButtons(_flowLayoutPanel.Width, _flowLayoutPanel.Margin);
            _flowLayoutPanel.Controls.AddRange(_themesButtons.Values.ToArray());

            _selectedTheme = data.Theme;
            _themesButtons[_selectedTheme].Image = _flag;

            foreach (var button in _themesButtons.Values)
                button.MouseClick += OnThemeClick;
        }

        private void OnOKClick(object sender, EventArgs e)
        {
            _settingsData.SetTheme(_selectedTheme, _chbRandomTheme.Checked);

            foreach (var design in _designs)
                design.SetTheme(_settingsData.Theme);

            Close();
        }

        private void OnThemeClick(object sender, EventArgs e)
        {
            if (sender is ButtonTheme button)
            {
                if (button.Theme != _selectedTheme)
                {
                    _themesButtons[_selectedTheme].Image = null;
                    _selectedTheme = button.Theme;
                    _themesButtons[_selectedTheme].Image = _flag;
                }
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            _flag.Dispose();
        }
    }
}
