using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    class FocusCell : Label
    {
        private readonly Color _backColor = Color.FromArgb(byte.MaxValue >> 1, Color.White);

        private SizeF _focusSize = new SizeF();
        private Rectangle _mapImageRectangle;

        public event Func<int, int, bool> CheckCell;

        public (int X, int Y) CellKey { get; private set; }

        public void SetLocation(int xMouse, int yMouse)
        {
            Visible = _mapImageRectangle.Contains(xMouse, yMouse);

            if (Visible)
            {
                int xCell = (int)((xMouse - _mapImageRectangle.X) / _focusSize.Width);
                int yCell = (int)((yMouse - _mapImageRectangle.Y) / _focusSize.Height);

                int xImage = (int)(xCell * _focusSize.Width + _mapImageRectangle.X);
                int yImage = (int)(yCell * _focusSize.Height + _mapImageRectangle.Y);

                BackColor = CheckCell.Invoke(xCell, yCell) ? _backColor : Color.Transparent;
                Location = new Point(xImage, yImage);
                CellKey = (xCell, yCell);
            }
        }

        public void ChangeSize(Size mapImageSize, Size clientSize, Size sizeMap)
        {
            _mapImageRectangle = Resizer.GetZoomedImageRectangle(mapImageSize, clientSize);

            _focusSize.Width = (float)_mapImageRectangle.Width / sizeMap.Width;
            _focusSize.Height = (float)_mapImageRectangle.Height / sizeMap.Height;

            Size = _focusSize.ToSize();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Visible = false;
        }
    }
}
