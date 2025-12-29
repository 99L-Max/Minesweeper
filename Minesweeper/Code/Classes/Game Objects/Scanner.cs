using System;
using System.Drawing;

namespace Minesweeper
{
    class Scanner : IDisposable
    {
        private Rectangle _imageRectangle;

        public Scanner(MapView mapView, int deltaY)
        {
            Image = Painter.CreateScannerImage(mapView.Theme, mapView.Image.Width, mapView.CellImageSize.Height);
            DeltaY = deltaY;

            _imageRectangle = new Rectangle(0, mapView.Image.Height, Image.Width, Image.Height);
        }

        public Image Image { get; }
        public int DeltaY { get; private set; }
        public Rectangle ImageRectangle => _imageRectangle;

        public void Dispose()
        {
            Image.Dispose();
        }

        public void Update()
        {
            _imageRectangle.Y += DeltaY;
        }
    }
}
