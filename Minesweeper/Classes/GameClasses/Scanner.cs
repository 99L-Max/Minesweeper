using System;
using System.Drawing;

namespace Minesweeper
{
    class Scanner : IDisposable
    {
        public readonly Image Image;

        public int Y { get; private set; }

        public Scanner(Theme theme, int width, int height, int startY)
        {
            Y = startY;
            Image = new Bitmap(width, height);

            var heightLight = height / 5;
            var colors = new Color[] { Color.Blue, Color.Lime, Color.Magenta };
            var color = colors[(int)theme < colors.Length ? (int)theme : 0];

            using (var g = Graphics.FromImage(Image))
            {
                for (int y = 0; y < height >> 1; y++)
                    using (var brush = new SolidBrush(Color.FromArgb((byte.MaxValue << 1) * y / height, color)))
                    using (var pen = new Pen(brush, 1f))
                    {
                        g.DrawLine(pen, 0, y, width, y);
                        g.DrawLine(pen, 0, height - y, width, height - y);
                    }

                g.FillRectangle(Brushes.White, 0, height - heightLight >> 1, width, heightLight);
            }
        }

        public void Dispose() =>
            Image.Dispose();

        public void Update(int dy) =>
            Y += dy;
    }
}
