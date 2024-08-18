using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    class LevelData
    {
        public readonly Dictionary<Level, int> Games;
        public readonly Dictionary<Level, int> Victories;
        public readonly Dictionary<Level, int> SeriesVictories;
        public readonly Dictionary<Level, int> SeriesLosses;
        public readonly Dictionary<Level, int> MaxSeriesVictories;
        public readonly Dictionary<Level, int> MaxSeriesLosses;
        public readonly Dictionary<Level, int> Session;
        public readonly Dictionary<Level, int?> BestTime;
        public readonly Dictionary<Level, List<string>> Records;

        public bool IsEmpty = true;

        public LevelData()
        {
            var keys = Enum.GetValues(typeof(Level)).Cast<Level>().Where(k => k != Level.Special);

            Games = keys.ToDictionary(k => k, v => 0);
            Victories = keys.ToDictionary(k => k, v => 0);
            Session = keys.ToDictionary(k => k, v => 0);
            SeriesVictories = keys.ToDictionary(k => k, v => 0);
            SeriesLosses = keys.ToDictionary(k => k, v => 0);
            MaxSeriesVictories = keys.ToDictionary(k => k, v => 0);
            MaxSeriesLosses = keys.ToDictionary(k => k, v => 0);
            BestTime = keys.ToDictionary(k => k, v => (int?)null);
            Records = keys.ToDictionary(k => k, v => new List<string>());
        }
    }
}
