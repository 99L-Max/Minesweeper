using Minesweeper.Properties;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Minesweeper
{
    class MapView : ISetTheme
    {
        private readonly Image _emptyImage;
        private readonly Dictionary<CellMark, Image> _cellMarkImages;
        private readonly Dictionary<MapLayers, MapLayerImage> _layers = new Dictionary<MapLayers, MapLayerImage>();

        private Graphics _graphics;
        private Image _closedCellImage;

        public MapView(Theme theme, int cellImageSize = 50)
        {
            CellImageSize = new Size(cellImageSize, cellImageSize);

            _emptyImage = new Bitmap(cellImageSize, cellImageSize);
            _cellMarkImages = ResourceImage.CutImagesByEnum<CellMark>(Resources.Marks);

            SetTheme(theme);
        }

        public Size CellImageSize { get; }
        public Theme Theme { get; private set; }
        public Image Image { get; private set; }

        public void SetTheme(Theme theme)
        {
            Theme = theme;
            _closedCellImage?.Dispose();
            _closedCellImage = ResourceImage.CutImageByEnum(Resources.Cell, theme);
        }

        public void ChangeLayers(Size mapSizeInCells)
        {
            var imageSize = new Size(CellImageSize.Width * mapSizeInCells.Width, CellImageSize.Height * mapSizeInCells.Height);

            if (_layers != null)
            {
                foreach (var layer in _layers.Values)
                    layer?.Dispose();

                _layers.Clear();
            }

            foreach (var layer in EnumFactory.GetValues<MapLayers>())
            {
                var mode = layer == MapLayers.Numbers ? CompositingMode.SourceOver : CompositingMode.SourceCopy;
                _layers.Add(layer, new MapLayerImage(imageSize, mode));
            }

            Image?.Dispose();
            Image = new Bitmap(imageSize.Width, imageSize.Height);

            _graphics?.Dispose();
            _graphics = Graphics.FromImage(Image);

            Repaint();
        }

        public void Repaint()
        {
            foreach (var layer in _layers.Values)
                _graphics.DrawImage(layer.Image, 0, 0, Image.Width, Image.Height);
        }

        public void ClearLayer(MapLayers layer)
        {
            _layers[layer].Clear();
            Repaint();
        }

        public void DrawCell(MapLayers layer, Image image, Cell cell)
        {
            _layers[layer].DrawCell(image ?? _emptyImage, cell);
            Repaint();
        }

        public void DrawCells(MapLayers layer, Image image, IEnumerable<Cell> cells)
        {
            _layers[layer].DrawCells(image ?? _emptyImage, cells);
            Repaint();
        }

        public void DrawOpenCells(IEnumerable<MapCell> cells)
        {
            var openedCells = cells.Where(cell => cell.IsClosed == false);

            _layers[MapLayers.Cells].DrawCells(_emptyImage, openedCells);
            _layers[MapLayers.Marks].DrawCells(_emptyImage, openedCells);

            Repaint();
        }

        public void DrawMark(MapCell cell)
        {
            _layers[MapLayers.Marks].DrawCell(_cellMarkImages[cell.Mark], cell);
            Repaint();
        }

        public void DrawMarks(IEnumerable<MapCell> cells)
        {
            foreach (var cell in cells)
                _layers[MapLayers.Marks].DrawCell(_cellMarkImages[cell.Mark], cell);

            Repaint();
        }

        public void DrawNotMines(IEnumerable<MapCell> cells)
        {
            var notMines = cells.Where(cell => cell.Mark == CellMark.Flag && cell.HasMine == false);

            using (var notMine = Painter.CreateNotMineImage(CellImageSize))
            {
                _layers[MapLayers.Cells].DrawCells(notMine, notMines);
                _layers[MapLayers.Marks].DrawCells(_emptyImage, notMines);
            }

            Repaint();
        }

        public void DrawClosedCells(IEnumerable<MapCell> cells)
        {
            _layers[MapLayers.Cells].DrawCells(_closedCellImage, cells.Where(cell => cell.IsClosed));
            Repaint();
        }

        public void DrawNumbers(IEnumerable<MapCell> cells, Size mapSizeInCells, float fontSize = 32f)
        {
            using (var image = Painter.CreateMapImage(mapSizeInCells, CellImageSize, fontSize, cells))
                _layers[MapLayers.Numbers].Draw(image);

            Repaint();
        }

        public void DrawEndGame(IEnumerable<MapCell> cells, bool isWin)
        {
            var mines = cells.Where(cell => cell.HasMine);

            if (isWin)
            {
                using (var mineImage = ResourceImage.CutImageByEnum(Resources.Mine, MineState.Inactive, 150))
                    foreach (var mine in mines)
                        _layers[MapLayers.Marks].DrawCell(mine.Mark != CellMark.Empty ? _cellMarkImages[mine.Mark] : mineImage, mine);
            }
            else
            {
                _layers[MapLayers.Cells].DrawCells(_emptyImage, mines);
            }

            Repaint();
        }

        public void DrawImage(Image image, Rectangle rectangle)
        {
            _graphics.DrawImage(image ?? _emptyImage, rectangle);
        }

        public void FillRectangle(Brush brush, Rectangle rectangle)
        {
            _graphics.FillRectangle(brush, rectangle);
        }
    }
}
