using Minesweeper.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    enum IconPosition { Left, Right }

    class VisualCounter : PictureBox
    {
        private readonly Image _icon;
        private readonly Image _image;
        private readonly Graphics _g;
        private readonly Rectangle _imageRectangle;

        private int _value;

        public readonly IconPosition IconPosition;

        public Theme? Theme { get; private set; } = null;

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                _g.Clear(Color.Transparent);

                TextRenderer.DrawText(_g, $"{_value}", Font, _imageRectangle, ForeColor);
                Image = _image;
            }
        }

        public VisualCounter(Image icon, IconPosition position, Theme theme)
        {
            IconPosition = position;
            SizeMode = PictureBoxSizeMode.Zoom;
            BackgroundImageLayout = ImageLayout.Zoom;
            Font = new Font("", 32, FontStyle.Bold);
            ForeColor = Color.White;
            BackColor = Color.Transparent;
            Dock = DockStyle.Fill;

            _icon = icon;
            _imageRectangle = new Rectangle(0, 0, 200, 50);
            _image = new Bitmap(_imageRectangle.Width, _imageRectangle.Height);
            _g = Graphics.FromImage(_image);

            ChangeDesign(theme);
        }

        public void ChangeDesign(Theme theme)
        {
            if (Theme != theme)
            {
                var backgroundImage = Painter.CutSprite(Resources.Counter, 3, 1, (int)theme, 0);
                var siteIcon = backgroundImage.Height;
                var xIcon = IconPosition == IconPosition.Left ? 0 : backgroundImage.Width - siteIcon;

                using (var g = Graphics.FromImage(backgroundImage))
                {
                    g.FillEllipse(Brushes.White, xIcon, 0, siteIcon, siteIcon);
                    g.DrawImage(_icon, xIcon, 0, siteIcon, siteIcon);
                }

                Theme = theme;
                BackgroundImage?.Dispose();
                BackgroundImage = backgroundImage;
            }
        }
    }
}
