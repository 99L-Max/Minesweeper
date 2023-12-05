using Minesweeper.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    enum Theme
    {
        Blue = 0,
        Green = 1,
        Purple = 2
    }

    partial class Design : Form
    {
        private readonly Bitmap flag;
        private readonly PictureBox[] themes;

        private int indexTheme;
        private Theme selectedTheme;

        private static bool isRandomTheme;

        public delegate void EventDesignChanged();
        public event EventDesignChanged DesignChanged;

        public static Theme Theme { private set; get; }

        static Design()
        {
            isRandomTheme = Settings.Default.IsRandomTheme;
            Theme = (Theme)Settings.Default.Theme;
        }

        public Design()
        {
            InitializeComponent();
            checkBoxRandomTheme.Checked = isRandomTheme;
            selectedTheme = Theme;
            flag = new Bitmap(Resources.Flag);

            themes = new PictureBox[]
            {
                pictureBox0,
                pictureBox1,
                pictureBox2
            };

            for (int i = 0; i < themes.Length; i++)
            {
                themes[i].Tag = i;
                themes[i].BackgroundImage = (Image)Resources.ResourceManager.GetObject($"Cell_{(Theme)i}");
            }

            indexTheme = (int)Theme;
            themes[indexTheme].Image = flag;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            isRandomTheme = checkBoxRandomTheme.Checked;

            if (isRandomTheme)
                selectedTheme = (Theme)(new Random()).Next(Enum.GetValues(typeof(Theme)).Length);

            if (selectedTheme != Theme)
            {
                Theme = selectedTheme;
                DesignChanged.Invoke();
            }

            Close();
        }

        private void PictureBoxTheme_Click(object sender, EventArgs e)
        {
            int index = (int)(sender as PictureBox).Tag;

            if (index != indexTheme)
            {
                selectedTheme = (Theme)index;
                themes[indexTheme].Image = null;
                themes[index].Image = flag;
                indexTheme = index;
            }
        }

        public static void WriteSettings()
        {
            Settings.Default.IsRandomTheme = isRandomTheme;
            Settings.Default.Theme = (int)Theme;
        }
    }
}
