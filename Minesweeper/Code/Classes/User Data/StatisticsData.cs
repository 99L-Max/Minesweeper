using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    class StatisticsData : ISave
    {
        [JsonProperty("LevelsStatistics")]
        private readonly Dictionary<Level, LevelStatistics> _levelsStatistics;

        public StatisticsData()
        {
            var levels = EnumFactory.GetValuesBySkip(Level.Special);
            _levelsStatistics = levels.ToDictionary(level => level, level => new LevelStatistics());
            IsEmpty = true;
        }

        [JsonConstructor]
        public StatisticsData(Dictionary<Level, LevelStatistics> levelsStatistics, bool isEmpty)
        {
            _levelsStatistics = levelsStatistics;
            IsEmpty = isEmpty;
        }

        public bool IsEmpty { get; private set; }

        public void Clear()
        {
            IsEmpty = true;

            foreach (LevelStatistics data in _levelsStatistics.Values)
                data.Clear();
        }

        public void Write(Level level, bool isWin, int gameSeconds = 0)
        {
            if (_levelsStatistics.ContainsKey(level))
            {
                _levelsStatistics[level].Update(isWin, gameSeconds);
                IsEmpty = false;
            }
        }

        public bool IsContainsLevel(Level level)
        {
            return _levelsStatistics.ContainsKey(level);
        }

        public string GetData(Level level)
        {
            return _levelsStatistics.ContainsKey(level) ? _levelsStatistics[level].GetData() : string.Empty;
        }

        public string GetVictoriesData(Level level)
        {
            return _levelsStatistics.ContainsKey(level) ? _levelsStatistics[level].GetVictoriesData() : string.Empty;
        }

        public string GetRecords(Level level)
        { 
            return _levelsStatistics.ContainsKey(level) ? _levelsStatistics[level].Records : string.Empty;
        }

        public int? GetBestTime(Level level)
        {
            return _levelsStatistics.ContainsKey(level) ? _levelsStatistics[level].BestTime : null;
        }

        public int GetPercentVictories(Level level)
        {
            return _levelsStatistics.ContainsKey(level) ? _levelsStatistics[level].PercentVictories : 0;
        }

        public void Save()
        {
            FileWriter.Save(this, GameDirectory.StatisticsFilePath);
        }
    }
}
