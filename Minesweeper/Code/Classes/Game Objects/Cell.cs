using Newtonsoft.Json;
using System.Drawing;

namespace Minesweeper
{
    abstract class Cell
    {
        [JsonConstructor]
        public Cell(int x, int y, Rectangle imageRectangle) : this(x, y)
        {
            ImageRectangle = imageRectangle;
        }

        public Cell(int x, int y, Size imageSize) : this(x, y)
        {
            ImageRectangle = new Rectangle(x * imageSize.Width, y * imageSize.Height, imageSize.Width, imageSize.Height);
        }

        public Cell(Cell cell) : this(cell.X, cell.Y, cell.ImageRectangle) { }

        private Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
        public Rectangle ImageRectangle { get; }
    }
}
