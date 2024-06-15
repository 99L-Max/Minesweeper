using System.Collections.Generic;
using System.Drawing;

namespace Minesweeper
{
    static class Painter
    {
        public static Image OverlayImages(Image back, Image front, Size size)
        {
            var image = new Bitmap(back, size);

            using (var g = Graphics.FromImage(image))
                g.DrawImage(front, 0, 0, size.Width, size.Height);

            return image;
        }

        public static Dictionary<int, Brush> GetFillBrushes(Color color, int dAlpha)
        {
            var brushes = new Dictionary<int, Brush>();

            for (int alpha = 0; alpha <= byte.MaxValue; alpha += dAlpha)
                brushes.Add(alpha, new SolidBrush(Color.FromArgb(alpha, color)));

            return brushes;
        }
    }
}
