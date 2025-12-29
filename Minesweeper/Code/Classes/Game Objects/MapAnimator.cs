using Minesweeper.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper
{
    class MapAnimator
    {
        private const int DeltaTime = 40;

        private readonly SoundPlayer _soundPlayer = new SoundPlayer();

        private bool _hasAnimationCanceled;

        public event Action FrameUpdated;

        public void SetSettings(in SettingsData data)
        {
            _soundPlayer.IsPlaySounds = data.GetSettings(GameSettings.IsPlaySounds);
        }

        public void CancelAnimation()
        {
            _hasAnimationCanceled = true;
        }

        public async Task ShowStart(MapView mapView, IEnumerable<MapCell> cells, int framesCount = 8)
        {
            using (var openCell = new Bitmap(Resources.OpenCell, mapView.CellImageSize))
                mapView.DrawCells(MapLayers.Cells, openCell, cells);

            FrameUpdated?.Invoke();

            var cellsFrameUpdateCount = cells.Count() / framesCount;
            var unrenderedCells = CellsHandler.Shuffle(cells);

            _soundPlayer.Play(Resources.Start);

            do
            {
                var renderedCells = unrenderedCells.Take(cellsFrameUpdateCount).ToArray();
                unrenderedCells = unrenderedCells.Skip(cellsFrameUpdateCount).ToArray();

                mapView.DrawClosedCells(renderedCells);
                FrameUpdated?.Invoke();

                await Task.Delay(DeltaTime);
            }
            while (unrenderedCells.Count() > 0);
        }

        public async Task ShowVictory(MapView mapView, IEnumerable<MapCell> cells, int milliseconds = 3000)
        {
            var deltaAlpha = 15;
            var scannerDeltaY = -mapView.Image.Height * DeltaTime / milliseconds;
            var brushes = new BrushesFactory().GetAlphaBrushes(Color.White, deltaAlpha);
            var mines = CellsHandler.CreateShowingMine(cells, mapView.Image.Height, DeltaTime, scannerDeltaY, deltaAlpha).ToArray();

            _hasAnimationCanceled = false;

            using (var mineImage = ResourceImage.CutImageByEnum(Resources.Mine, MineState.Inactive, 150))
            using (var scanner = new Scanner(mapView, scannerDeltaY))
            {
                mapView.ClearLayer(MapLayers.Marks);

                FrameUpdated?.Invoke();

                _soundPlayer.Play(Resources.Win);

                do
                {
                    mapView.Repaint();

                    foreach (var mine in mines)
                    {
                        mine.Update(DeltaTime);

                        mapView.DrawImage(mine.Visible ? mineImage : null, mine.ImageRectangle);
                        mapView.FillRectangle(brushes[mine.Alpha], mine.ImageRectangle);
                    }

                    scanner.Update();
                    mapView.DrawImage(scanner.Image, scanner.ImageRectangle);

                    FrameUpdated?.Invoke();
                    await Task.Delay(DeltaTime);

                    if (_hasAnimationCanceled)
                        break;
                }
                while (scanner.ImageRectangle.Y > -scanner.Image.Height || mines.Any(mine => mine.IsShowed == false));

                foreach (var brush in brushes.Values)
                    brush.Dispose();
            }
        }

        public async Task ShowLoss(MapView mapView, IEnumerable<MapCell> cells, MapCell sender)
        {
            _hasAnimationCanceled = false;

            var mines = CellsHandler.CreateExplodingMines(cells, sender, DeltaTime).ToArray();
            var cellImage = ResourceImage.CutImageByEnum(Resources.Cell, mapView.Theme);
            var framesExplosion = ResourceImage.CutColumnIntoFrames(Resources.Explosion, MineExplosion.MaxBoomStage);

            framesExplosion.Insert(0, cellImage);
            mapView.DrawCells(MapLayers.Cells, null, mines);

            do
            {
                mapView.Repaint();

                foreach (var mine in mines)
                {
                    mine.Update(DeltaTime);
                    mapView.DrawImage(mine.IsExploded ? null : framesExplosion[mine.BoomStage], mine.ImageRectangle);
                }

                if (mines.Count(mine => mine.Delay <= 0 && mine.BoomStage == 0) > 0)
                    _soundPlayer.Play(Resources.Boom);

                FrameUpdated?.Invoke();

                await Task.Delay(DeltaTime);

                if (_hasAnimationCanceled)
                    break;
            }
            while (mines.Any(mine => mine.IsExploded == false));

            framesExplosion.ForEach(frame => frame.Dispose());
        }

        public async Task ShowError(MapView mapView, MapCell sender, int framesCount = 6)
        {
            using (var cross = new Bitmap(Resources.Cross, mapView.CellImageSize))
            using (var empty = new Bitmap(mapView.CellImageSize.Width, mapView.CellImageSize.Height))
            {
                _soundPlayer.Play(Resources.Error);

                for (int i = 0; i < framesCount; i++)
                {
                    mapView.DrawCell(MapLayers.Cells, (i & 1) == 0 ? cross : empty, sender);
                    FrameUpdated?.Invoke();
                    await Task.Delay(DeltaTime);
                }
            }
        }
    }
}
