using Minesweeper.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    class VisualCounter : PictureBox, ISetTheme
    {
        private readonly Image _valueImage;
        private readonly Graphics _graphics;
        private readonly Rectangle _valueRectangle;

        private int _value;

        public VisualCounter(Theme theme, int maxValue = int.MaxValue)
        {
            SizeMode = PictureBoxSizeMode.Zoom;
            BackgroundImageLayout = ImageLayout.Zoom;
            Font = new Font("", 64, FontStyle.Bold);
            ForeColor = Color.White;
            BackColor = Color.Transparent;
            Dock = DockStyle.Fill;
            MaxValue = maxValue;

            _valueRectangle = new Rectangle(0, 0, 400, 100);
            _valueImage = new Bitmap(_valueRectangle.Width, _valueRectangle.Height);
            _graphics = Graphics.FromImage(_valueImage);

            SetTheme(theme);
        }

        public Theme? Theme { get; private set; } = null;
        public int MaxValue { get; }
        public int Value
        {
            get => _value;
            set => SetValue(value);
        }

        public void SetTheme(Theme theme)
        {
            if (Theme != theme)
            {
                Theme = theme;
                BackgroundImage?.Dispose();
                BackgroundImage = ResourceImage.CutImageByEnum(Resources.Counter, theme);
            }
        }

        private void SetValue(int value)
        {
            _value = value > MaxValue ? MaxValue : value;
            _graphics.Clear(Color.Transparent);

            TextRenderer.DrawText(_graphics, $"{_value}", Font, _valueRectangle, ForeColor);
            Image = _valueImage;
        }
    }
}
