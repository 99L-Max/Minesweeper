using System.Drawing;

namespace Minesweeper
{
    static class Scanner
    {
        public static Bitmap GetBitmap(int width, int height, Theme theme)
        {
            Bitmap bitmap = new Bitmap(width, height);
            int heightLight = height * 2 / 5;

            Color color;

            switch (theme)
            {
                default:
                    color = Color.DodgerBlue;
                    break;
                case Theme.Green:
                    color = Color.Lime;
                    break;
                case Theme.Purple:
                    color = Color.Magenta;
                    break;
            }

            using (Bitmap part = new Bitmap(width, heightLight))
            {
                using (Graphics g = Graphics.FromImage(part))
                    for (int y = 0; y < heightLight; y++)
                        g.DrawLine(new Pen(Color.FromArgb((byte.MaxValue * y / heightLight), color)), 0, y, width, y);

                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.DrawImage(part, 0, 0);

                    part.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    g.DrawImage(part, 0, height - heightLight);

                    g.FillRectangle(new SolidBrush(Color.White), 0, heightLight, width, height - 2 * heightLight);
                }
            }

            return bitmap;
        }
    }
}
