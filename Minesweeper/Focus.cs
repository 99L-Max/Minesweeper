using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    class Focus : Label
    {
        private readonly Color baseColor;

        private float widthF;
        private float heightF;
        private Point leftUpPoint;
        private Point rightDownPoint;

        public delegate bool EventCheckCell(int x, int y);
        public event EventCheckCell CheckCell;

        public (int, int) KeyCell { private set; get; }

        public Focus()
        {
            baseColor = Color.FromArgb(byte.MaxValue >> 1, Color.White);
            MouseLeave += (s, e) => Visible = false;
        }

        public void SetLocation(int xMouse, int yMouse)
        {
            Visible = xMouse > leftUpPoint.X && xMouse < rightDownPoint.X && yMouse > leftUpPoint.Y && yMouse < rightDownPoint.Y;

            if (Visible)
            {
                int x = (int)((xMouse - leftUpPoint.X) / widthF);
                int y = (int)((yMouse - leftUpPoint.Y) / heightF);

                KeyCell = (x, y);
                Location = new Point((int)(x * widthF + leftUpPoint.X), (int)(y * heightF + leftUpPoint.Y));
                BackColor = CheckCell.Invoke(x, y) ? baseColor : Color.Transparent;
            }
        }

        public new void Resize(Size sizePictureBox, Size sizeImageMap, Size sizeMap)
        {
            float wfactor = (float)sizeImageMap.Width / sizePictureBox.Width;
            float hfactor = (float)sizeImageMap.Height / sizePictureBox.Height;

            float resizeFactor = Math.Max(wfactor, hfactor);
            Size sizeImage = new Size((int)(sizeImageMap.Width / resizeFactor), (int)(sizeImageMap.Height / resizeFactor));

            leftUpPoint = new Point((sizePictureBox.Width - sizeImage.Width) >> 1, (sizePictureBox.Height - sizeImage.Height) >> 1);
            rightDownPoint = new Point(leftUpPoint.X + sizeImage.Width, leftUpPoint.Y + sizeImage.Height);

            widthF = (float)sizeImage.Width / sizeMap.Width;
            heightF = (float)sizeImage.Height / sizeMap.Height;

            Size = new Size((int)widthF, (int)heightF);
        }
    }
}
