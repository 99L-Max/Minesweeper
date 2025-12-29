using Minesweeper.Properties;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Minesweeper
{
    static class Painter
    {
        public static Image CreateMapImage(Size sizeInCells, Size cellImageSize, float fontSize, IEnumerable<MapCell> cells)
        {
            var imageMap = new Bitmap(sizeInCells.Width * cellImageSize.Width, sizeInCells.Height * cellImageSize.Height);
            var brushes = new BrushesFactory().GetBrushes();

            using (var g = Graphics.FromImage(imageMap))
            using (var mineImage = ResourceImage.CutImageByEnum(Resources.Mine, MineState.Exploded))
            using (var openCell = Resources.OpenCell)
            using (var font = new Font("", fontSize, FontStyle.Bold))
            using (var format = new StringFormat())
            {
                format.Alignment = format.LineAlignment = StringAlignment.Center;

                foreach (var cell in cells)
                {
                    g.DrawImage(openCell, cell.ImageRectangle);

                    if (cell.HasMine)
                        g.DrawImage(mineImage, cell.ImageRectangle);
                    else if (cell.MinesNearbyCount > 0)
                        g.DrawString($"{cell.MinesNearbyCount}", font, brushes[cell.MinesNearbyCount - 1], cell.ImageRectangle, format);
                }
            }

            brushes.ForEach(brush => brush.Dispose());

            return imageMap;
        }

        public static Image CreateScannerImage(Theme theme, int width, int height, int lightHeightReductionFactor = 5)
        {
            var image = new Bitmap(width, height);
            var color = new ScannerColorsFactory().GetColor(theme);

            var angle = 90f;
            var halfHeight = height >> 1;
            var lightHeight = height / lightHeightReductionFactor;

            var upperRectangle = new Rectangle(0, 0, width, halfHeight);
            var lowerRectangle = new Rectangle(0, halfHeight, width, halfHeight);
            var lightRectangle = new Rectangle(0, height - lightHeight >> 1, width, lightHeight);

            var borderColor = Color.FromArgb(byte.MinValue, color);
            var centerColor = Color.FromArgb(byte.MaxValue, color);

            using (var g = Graphics.FromImage(image))
            using (var upperBruch = new LinearGradientBrush(upperRectangle, borderColor, centerColor, angle))
            using (var lowerBrush = new LinearGradientBrush(lowerRectangle, centerColor, borderColor, angle))
            {
                g.FillRectangle(upperBruch, upperRectangle);
                g.FillRectangle(lowerBrush, lowerRectangle);
                g.FillRectangle(Brushes.White, lightRectangle);
            }

            return image;
        }

        public static Image CreateFilledImage(Color color, int alpha, int width, int height)
        {
            var image = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(image))
                g.Clear(Color.FromArgb(alpha, color));

            return image;
        }

        public static Image CreateNotMineImage(Size size)
        {
            using (var mine = ResourceImage.CutImageByEnum(Resources.Mine, MineState.Exploded))
            using (var openCell = Resources.OpenCell)
            using (var cross = Resources.Cross)
                return Overlay(size, openCell, mine, cross);
        }

        public static Image Overlay(Size size, params Image[] images)
        {
            var result = new Bitmap(size.Width, size.Height);

            using (var g = Graphics.FromImage(result))
                foreach (var image in images)
                    g.DrawImage(image, 0, 0, size.Width, size.Height);

            return result;
        }

        public static Image DrawImageAlpha(Image sprite, Rectangle destRect, Rectangle srcRect, byte alpha)
        {
            var result = new Bitmap(destRect.Width, destRect.Height);

            using (var g = Graphics.FromImage(result))
            {
                if (alpha < byte.MaxValue)
                {
                    var matrix = new ColorMatrix { Matrix33 = (alpha + 1f) / byte.MaxValue };
                    var rectangle = new Rectangle(0, 0, result.Width, result.Height);

                    using (var attribute = new ImageAttributes())
                    {
                        attribute.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                        g.DrawImage(sprite, destRect, 0, 0, result.Width, result.Height, GraphicsUnit.Pixel, attribute);
                    }
                }
                else
                {
                    g.DrawImage(sprite, destRect, srcRect, GraphicsUnit.Pixel);
                }
            }

            return result;
        }
    }
}
