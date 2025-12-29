using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    class ButtonTheme : PictureBox
    {
        private readonly Image _focusImage;

        private bool _isHovered = false;

        public ButtonTheme(Theme theme, Image backgroundImage, int size)
        {
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackgroundImageLayout = ImageLayout.Stretch;

            Theme = theme;
            Width = size;
            Height = size;
            BackgroundImage = backgroundImage;

            _focusImage = Painter.CreateFilledImage(Color.White, byte.MaxValue / 3, size, size);
        }

        public Theme Theme { get; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_isHovered)
                e.Graphics.DrawImage(_focusImage, ClientRectangle);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _isHovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _isHovered = false;
            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _focusImage?.Dispose();

            base.Dispose(disposing);
        }
    }
}
