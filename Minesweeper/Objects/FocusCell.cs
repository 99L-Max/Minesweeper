using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    class FocusCell : Label
    {
        private static readonly Color s_baseColor;

        private float _widthF;
        private float _heightF;
        private Point _leftUpPointMap;
        private Point _rightDownPointMap;

        public Func<int, int, bool> CheckCell;

        public (int, int) KeyCell { get; private set; }

        static FocusCell() =>
            s_baseColor = Color.FromArgb(byte.MaxValue >> 1, Color.White);

        protected override void OnMouseLeave(EventArgs e) =>
            Visible = false;

        public void SetLocation(int xMouse, int yMouse)
        {
            Visible = xMouse > _leftUpPointMap.X && xMouse < _rightDownPointMap.X && yMouse > _leftUpPointMap.Y && yMouse < _rightDownPointMap.Y;

            if (Visible)
            {
                int x = (int)((xMouse - _leftUpPointMap.X) / _widthF);
                int y = (int)((yMouse - _leftUpPointMap.Y) / _heightF);

                KeyCell = (x, y);
                Location = new Point((int)(x * _widthF + _leftUpPointMap.X), (int)(y * _heightF + _leftUpPointMap.Y));
                BackColor = CheckCell.Invoke(x, y) ? s_baseColor : Color.Transparent;
            }
        }

        public void ChangeSize(Size sizePictureBox, Size sizeImageMap, Size sizeMap)
        {
            var wFactor = (float)sizeImageMap.Width / sizePictureBox.Width;
            var hFactor = (float)sizeImageMap.Height / sizePictureBox.Height;

            var resizeFactor = Math.Max(wFactor, hFactor);
            var sizeImage = new Size((int)(sizeImageMap.Width / resizeFactor), (int)(sizeImageMap.Height / resizeFactor));

            _leftUpPointMap = new Point(sizePictureBox.Width - sizeImage.Width >> 1, sizePictureBox.Height - sizeImage.Height >> 1);
            _rightDownPointMap = new Point(_leftUpPointMap.X + sizeImage.Width, _leftUpPointMap.Y + sizeImage.Height);

            _widthF = (float)sizeImage.Width / sizeMap.Width;
            _heightF = (float)sizeImage.Height / sizeMap.Height;

            Size = new Size((int)_widthF, (int)_heightF);
        }
    }
}
