using Newtonsoft.Json;
using System.Drawing;

namespace Minesweeper
{
    struct LevelSettings
    {
        [JsonConstructor]
        public LevelSettings(string title, int minesCount, Size mapSize)
        {
            Title = title;
            MinesCount = minesCount;
            MapSize = mapSize;
        }

        public string Title { get; }
        public int MinesCount { get; }
        public Size MapSize { get; }
    }
}
