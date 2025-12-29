using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Minesweeper
{
    class MapLayerImage : IDisposable
    {
        private readonly Graphics _graphics;
        
        public MapLayerImage(Size size, CompositingMode mode)
        {
            Image = new Bitmap(size.Width, size.Height);
            _graphics = Graphics.FromImage(Image);
            _graphics.CompositingMode = mode;
        }

        public Image Image { get; private set; }

        public void Dispose()
        {
            _graphics?.Dispose();
            Image?.Dispose();
        }

        public void Draw(Image image)
        {
            _graphics.DrawImage(image, 0, 0, Image.Width, Image.Height);
        }

        public void DrawCell(Image image, Cell cell)
        {
            _graphics.DrawImage(image, cell.ImageRectangle);
        }

        public void DrawCells(Image image, IEnumerable<Cell> cells)
        {
            foreach (var cell in cells)
                _graphics.DrawImage(image, cell.ImageRectangle);
        }

        public void Clear()
        {
            _graphics.Clear(Color.Transparent);
        }
    }
}
