using Minesweeper.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    partial class FormDesign : Form
    {
        private readonly Image _flag;
        private readonly PictureBox[] _themes;
        private readonly SettingsData _settingsData;

        private int _indexTheme;
        private Theme _selectedTheme;

        public FormDesign(SettingsData data)
        {
            InitializeComponent();

            _settingsData = data;
            _selectedTheme = _settingsData.Theme;
            _chbRandomTheme.Checked = _settingsData.IsRandomTheme;
            _flag = new Bitmap(Resources.Flag);
            _themes = new PictureBox[] { _pb0, _pb1, _pb2 };

            for (int i = 0; i < _themes.Length; i++)
                _themes[i].Tag = i;

            _indexTheme = (int)_selectedTheme;
            _themes[_indexTheme].Image = _flag;
        }

        private void OnThemeClick(object sender, EventArgs e)
        {
            if (sender is PictureBox pb)
            {
                int index = (int)pb.Tag;

                if (index != _indexTheme)
                {
                    _selectedTheme = (Theme)index;
                    _themes[_indexTheme].Image = null;
                    _themes[index].Image = _flag;
                    _indexTheme = index;
                }
            }
        }

        private void OnOKClick(object sender, EventArgs e)
        {
            _settingsData.SetTheme(_selectedTheme, _chbRandomTheme.Checked);
            Close();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e) =>
            _flag.Dispose();
    }
}
