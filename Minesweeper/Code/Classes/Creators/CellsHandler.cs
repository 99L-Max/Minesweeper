using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Minesweeper
{
    static class CellsHandler
    {
        public static IEnumerable<(int, int)> GetMinesLocation(Size sizeInCells, int mineCount, (int x, int y) cellSender)
        {
            var locations = new List<(int, int)>();

            var leftBoundX = cellSender.x - 1;
            var leftBoundY = cellSender.y - 1;

            var rightBoundX = cellSender.x + 1;
            var rightBoundY = cellSender.y + 1;

            for (int x = 0; x < sizeInCells.Width; x++)
                for (int y = 0; y < sizeInCells.Height; y++)
                    if (x < leftBoundX || x > rightBoundX || y < leftBoundY || y > rightBoundY)
                        locations.Add((x, y));

            while (mineCount-- > 0 && locations.Count > 0)
            {
                var randomIndex = GameRandom.Next(locations.Count);

                yield return locations[randomIndex];

                locations.RemoveAt(randomIndex);
            }
        }

        public static IEnumerable<MineExplosion> CreateExplodingMines(IEnumerable<MapCell> cells, MapCell sender, int deltaTime, int maxDelayFramesSound = 5, int distanceTimeConverter = 4)
        {
            foreach (var cell in cells.Where(cell => cell.HasMine))
            {
                var dx = sender.X - cell.X;
                var dy = sender.Y - cell.Y;
                var distance = (int)Math.Sqrt(dx * dx + dy * dy);
                var delay = (distanceTimeConverter * distance + GameRandom.Next(maxDelayFramesSound)) * deltaTime;

                yield return new MineExplosion(cell, delay);
            }
        }

        public static IEnumerable<MineAlpha> CreateShowingMine(IEnumerable<MapCell> cells, int mapHeight, int deltaTime, int scannerDeltaY, int deltaAlpha)
        {
            foreach (var cell in cells.Where(cell => cell.HasMine))
            {
                var delay = (cell.ImageRectangle.Y - mapHeight) / scannerDeltaY * deltaTime;
                yield return new MineAlpha(cell, delay, deltaAlpha);
            }
        }

        public static MapCell[] Shuffle(IEnumerable<MapCell> cells)
        {
            switch (GameRandom.Next(3))
            {
                case 0:
                    return cells.OrderBy(cell => cell.X + cell.Y).ToArray();
            
                case 1:
                    return cells.OrderBy(cell => ((cell.X + cell.Y & 1) == 0) ? 1 : 0).ToArray();
            
                default:
                    return cells.OrderBy(cell => GameRandom.Next()).ToArray();
            }
        }
    }
}
