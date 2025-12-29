using System.Drawing;

namespace Minesweeper
{
    static class Resizer
    {
        public static Rectangle GetZoomedImageRectangle(Size imageSize, Size clientSize)
        {
            float ratioImg = (float)imageSize.Width / imageSize.Height;
            float ratioBox = (float)clientSize.Width / clientSize.Height;

            int drawWidth, drawHeight;
            int offsetX, offsetY;

            if (ratioBox > ratioImg)
            {
                drawHeight = clientSize.Height;
                drawWidth = (int)(drawHeight * ratioImg);
            }
            else
            {
                drawWidth = clientSize.Width;
                drawHeight = (int)(drawWidth / ratioImg);
            }

            offsetX = clientSize.Width - drawWidth >> 1;
            offsetY = clientSize.Height - drawHeight >> 1;

            return new Rectangle(offsetX, offsetY, drawWidth, drawHeight);
        }
    }
}
