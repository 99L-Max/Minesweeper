using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    class LevelStatistics
    {
        private const int MaxPercent = 100;
        private const int RecordsMaxCount = 5;

        [JsonProperty("Records")] 
        private List<string> _records = new List<string>();

        public LevelStatistics() { }

        [JsonConstructor]
        public LevelStatistics(int games, int victories, int seriesVictories, int seriesLosses, int maxSeriesVictories, int maxSeriesLosses, int session, int? bestTime, IEnumerable<string> records)
        {
            _records = new List<string>(records);

            Games = games;
            Victories = victories;
            SeriesVictories = seriesVictories;
            SeriesLosses = seriesLosses;
            MaxSeriesVictories = maxSeriesVictories;
            MaxSeriesLosses = maxSeriesLosses;
            Session = session;
            BestTime = bestTime;
        }

        public int Games { get; private set; } = 0;
        public int Victories { get; private set; } = 0;
        public int SeriesVictories { get; private set; } = 0;
        public int SeriesLosses { get; private set; } = 0;
        public int MaxSeriesVictories { get; private set; } = 0;
        public int MaxSeriesLosses { get; private set; } = 0;
        public int Session { get; private set; } = 0;
        public int? BestTime { get; private set; } = null;

        [JsonIgnore] 
        public string Records => string.Join(Environment.NewLine, _records);
        [JsonIgnore] 
        public int PercentVictories => Games > 0 ? MaxPercent * Victories / Games : 0;

        public string GetVictoriesData()
        {
            var result = BestTime != null ? $"Лучшее время: {BestTime} сек." : string.Empty;
            return $"{result}\n\nПроведено игр: {Games}\n\nВыиграно: {Victories}";
        }

        public string GetData()
        {
            return
                $"Проведено игр: {Games}{Environment.NewLine}" +
                $"Выиграно: {Victories}{Environment.NewLine}" +
                $"Процент выигрышей: {PercentVictories}%{Environment.NewLine}" +
                $"Выигрышей подряд: {MaxSeriesVictories}{Environment.NewLine}" +
                $"Проигрышей подряд: {MaxSeriesLosses}{Environment.NewLine}" +
                $"В текущем сеансе: {Session}";
        }

        public void Update(bool isWin, int gameSeconds = 0)
        {
            Games++;

            if (isWin)
            {
                Victories++;
                Session++;

                SeriesVictories++;
                SeriesLosses = 0;

                if (MaxSeriesVictories < SeriesVictories)
                    MaxSeriesVictories = SeriesVictories;

                if (BestTime == null || BestTime > gameSeconds)
                    BestTime = gameSeconds;

                _records.Add($"{gameSeconds}\t{DateTime.Now:d}");
                _records = _records.OrderBy(record => record).Take(RecordsMaxCount).ToList();
            }
            else
            {
                Session--;

                SeriesLosses++;
                SeriesVictories = 0;

                if (MaxSeriesLosses < SeriesLosses)
                    MaxSeriesLosses = SeriesLosses;
            }
        }

        public void Clear()
        {
            _records.Clear();

            Games = 0;
            Victories = 0;
            SeriesVictories = 0;
            SeriesLosses = 0;
            MaxSeriesVictories = 0;
            MaxSeriesLosses = 0;
            Session = 0;
            BestTime = null;
        }
    }
}
