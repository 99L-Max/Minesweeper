using System.Collections.Generic;
using System.Drawing;

namespace Minesweeper
{
    static class Painter
    {
        public static Image CutSprite(Image sprite, int rowsCount, int columnsCount, int row, int column, Size? size = null, bool isDisposeSprite = true)
        {
            var width = sprite.Width / columnsCount;
            var height = sprite.Height / rowsCount;
            var sizeImage = size != null ? (Size)size : new Size(width, height);

            var destRect = new Rectangle(new Point(), sizeImage);
            var srcRect = new Rectangle(column * width, row * height, width, height);

            var image = new Bitmap(destRect.Width, destRect.Height);

            using (var g = Graphics.FromImage(image))
                g.DrawImage(sprite, destRect, srcRect, GraphicsUnit.Pixel);

            if (isDisposeSprite)
                sprite.Dispose();

            return image;
        }

        public static List<Image> CutSprite(Image sprite, int rowsCount, int columnsCount, Size? sizeImages = null, bool isDisposeSprite = true)
        {
            var list = new List<Image>();

            for (int row = 0; row < rowsCount; row++)
                for (int column = 0; column < columnsCount; column++)
                    list.Add(CutSprite(sprite, rowsCount, columnsCount, row, column, sizeImages, false));

            if (isDisposeSprite)
                sprite.Dispose();

            return list;
        }

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
