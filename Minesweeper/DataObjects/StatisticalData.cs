using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace Minesweeper
{
    class StatisticalData
    {
        private LevelData _levelData;

        public bool IsEmpty =>
            _levelData.IsEmpty;

        public StatisticalData(string path)
        {
            try
            {
                using (var reader = new StreamReader(path + @"\Statistics.json"))
                    _levelData = JsonConvert.DeserializeObject<LevelData>(reader.ReadToEnd());
            }
            catch (Exception)
            {
                _levelData = new LevelData();
            }
        }

        public void Clear() =>
            _levelData = new LevelData();

        public void Write(Level level, bool isWin, int gameSeconds = 0)
        {
            if (level == Level.Special) return;

            _levelData.IsEmpty = false;

            _levelData.Games[level]++;

            if (isWin)
            {
                _levelData.Victories[level]++;
                _levelData.Session[level]++;

                _levelData.SeriesVictories[level]++;
                _levelData.SeriesLosses[level] = 0;

                if (_levelData.MaxSeriesVictories[level] < _levelData.SeriesVictories[level])
                    _levelData.MaxSeriesVictories[level] = _levelData.SeriesVictories[level];

                if (_levelData.BestTime[level] == null || gameSeconds < _levelData.BestTime[level])
                    _levelData.BestTime[level] = gameSeconds;

                //Запоминать только 5 лучших результатов
                _levelData.Records[level].Add($"{gameSeconds}\t{DateTime.Now:d}");
                _levelData.Records[level] = _levelData.Records[level].OrderBy(x => x).Take(5).ToList();
            }
            else
            {
                _levelData.Session[level]--;

                _levelData.SeriesLosses[level]++;
                _levelData.SeriesVictories[level] = 0;

                if (_levelData.MaxSeriesLosses[level] < _levelData.SeriesLosses[level])
                    _levelData.MaxSeriesLosses[level] = _levelData.SeriesLosses[level];
            }
        }

        public string GetData(Level level)
        {
            var percent = _levelData.Games[level] == 0 ? 0 : _levelData.Victories[level] * 100 / _levelData.Games[level];
            var enter = Environment.NewLine;

            return
                $"Проведено игр: {_levelData.Games[level]}{enter}" +
                $"Выиграно: {_levelData.Victories[level]}{enter}" +
                $"Процент выигрышей: {percent}%{enter}" +
                $"Выигрышей подряд: {_levelData.MaxSeriesVictories[level]}{enter}" +
                $"Проигрышей подряд: {_levelData.MaxSeriesLosses[level]}{enter}" +
                $"В текущем сеансе: {_levelData.Session[level]}";
        }

        public string GetRecords(Level level) =>
            string.Join($"{Environment.NewLine}", _levelData.Records[level]);

        public string GetVictoriesData(Level level)
        {
            var result = string.Empty;

            if (level == Level.Special)
                return result;

            if (_levelData.BestTime[level] != null)
                result += $"Лучшее время: {_levelData.BestTime[level]} сек.";

            result +=
                $"\n\n" +
                $"Проведено игр: {_levelData.Games[level]}\n\n" +
                $"Выиграно: {_levelData.Victories[level]}";

            return result;
        }

        public int? GetBestTime(Level level) =>
            level != Level.Special ? _levelData.BestTime[level] : 0;

        public int GetPercentVictories(Level level) =>
            100 * _levelData.Victories[level] / _levelData.Games[level];

        public void Save(string pathSave)
        {
            var data = JsonConvert.SerializeObject(_levelData);
            File.WriteAllText(pathSave + @"\Statistics.json", data);
        }
    }
}
