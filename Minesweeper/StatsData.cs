using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    class StatsData
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
        public bool IsEmpty;

        public StatsData()
        {
            IsEmpty = true;

            Games = new Dictionary<Level, int>();
            Victories = new Dictionary<Level, int>();
            SeriesVictories = new Dictionary<Level, int>();
            SeriesLosses = new Dictionary<Level, int>();
            MaxSeriesVictories = new Dictionary<Level, int>();
            MaxSeriesLosses = new Dictionary<Level, int>();
            Session = new Dictionary<Level, int>();
            BestTime = new Dictionary<Level, int?>();
            Records = new Dictionary<Level, List<string>>();

            List<Level> keys = Enum.GetValues(typeof(Level)).Cast<Level>().Where(k => k != Level.Special).ToList();

            foreach (var key in keys)
            {
                Games.Add(key, 0);
                Victories.Add(key, 0);
                Session.Add(key, 0);
                SeriesVictories.Add(key, 0);
                SeriesLosses.Add(key, 0);
                MaxSeriesVictories.Add(key, 0);
                MaxSeriesLosses.Add(key, 0);
                BestTime.Add(key, null);
                Records.Add(key, new List<string>());
            }
        }

        public void Clear()
        {
            Games.Keys.ToList().ForEach(x => Games[x] = 0);
            Victories.Keys.ToList().ForEach(x => Victories[x] = 0);
            Session.Keys.ToList().ForEach(x => Session[x] = 0);
            SeriesVictories.Keys.ToList().ForEach(x => SeriesVictories[x] = 0);
            SeriesLosses.Keys.ToList().ForEach(x => SeriesLosses[x] = 0);
            MaxSeriesVictories.Keys.ToList().ForEach(x => MaxSeriesVictories[x] = 0);
            MaxSeriesLosses.Keys.ToList().ForEach(x => MaxSeriesLosses[x] = 0);
            BestTime.Keys.ToList().ForEach(x => BestTime[x] = null);
            Records.Keys.ToList().ForEach(x => Records[x].Clear());

            IsEmpty = true;
        }
    }
}
