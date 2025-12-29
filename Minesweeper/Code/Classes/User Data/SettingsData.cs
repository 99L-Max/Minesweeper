using Minesweeper.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Minesweeper
{
    class SettingsData : ISave
    {
        public const int MapMinWidth = 9;
        public const int MapMinHeight = 9;
        public const int MinesMinCount = 10;
        public const int MapMaxWidth = 30;
        public const int MapMaxHeight = 24;

        [JsonProperty("GameSettings")]
        private readonly Dictionary<GameSettings, bool> _gameSettings;

        static SettingsData()
        {
            var data = FileReader.GetDictionary<Level, LevelSettings>(Resources.LevelSettings);
            LevelData = new ReadOnlyDictionary<Level, LevelSettings>(data);
        }

        public SettingsData()
        {
            _gameSettings = FileReader.GetDictionary<GameSettings, bool>(Resources.DefaultSettings);
            SetLevel(Level.Easy);
        }

        [JsonConstructor]
        public SettingsData(Level level, Theme theme, Size mapSize, int minesCount, int specialMapWidth, int specialMapHeight, int specialMinesCount, bool isRandomTheme, Dictionary<GameSettings, bool> gameSettings)
        {
            _gameSettings = gameSettings;

            Level = level;
            Theme = theme;
            MapSize = mapSize;
            MinesCount = minesCount;
            SpecialMapWidth = specialMapWidth;
            SpecialMapHeight = specialMapHeight;
            SpecialMinesCount = specialMinesCount;
            IsRandomTheme = isRandomTheme;
        }

        public static ReadOnlyDictionary<Level, LevelSettings> LevelData { get; }

        public Level Level { get; private set; }
        public Theme Theme { get; private set; } = Theme.Blue;
        public Size MapSize { get; private set; }
        public int MinesCount { get; private set; }
        public int SpecialMapWidth { get; private set; } = 10;
        public int SpecialMapHeight { get; private set; } = 10;
        public int SpecialMinesCount { get; private set; } = 10;
        public bool IsRandomTheme { get; private set; } = false;

        public static string GetLevelDescription(Level level)
        {
            if (LevelData.ContainsKey(level))
            {
                return
                    $"{LevelData[level].Title}\n" +
                    $"{LevelData[level].MinesCount} мин\n" +
                    $"поле {LevelData[level].MapSize.Width} x {LevelData[level].MapSize.Height} ячеек";
            }
            else
            {
                return "Особый";
            }
        }

        public static decimal GetMinesMaxCount(decimal cellsCount)
        {
            return Math.Round(0.94m * cellsCount - 8.91m);
        }

        public void SetTheme(Theme theme, bool isRandomTheme)
        {
            IsRandomTheme = isRandomTheme;
            Theme = IsRandomTheme ? EnumFactory.GetRandomValue<Theme>() : theme;
        }

        public void SetLevel(Level level)
        {
            Level = level;

            if (LevelData.ContainsKey(level))
            {
                MapSize = LevelData[level].MapSize;
                MinesCount = LevelData[level].MinesCount;
            }
            else
            {
                MapSize = new Size(SpecialMapWidth, SpecialMapHeight);
                MinesCount = SpecialMinesCount;
            }
        }

        public void SetSpecialLevelData(int mapWidth, int mapHeight, int minesCount)
        {
            SpecialMapWidth = mapWidth;
            SpecialMapHeight = mapHeight;
            SpecialMinesCount = minesCount;
        }

        public void SetSettings(IDictionary<GameSettings, bool> settings)
        {
            foreach (var data in settings)
                if (_gameSettings.ContainsKey(data.Key))
                    _gameSettings[data.Key] = data.Value;
        }

        public bool GetSettings(GameSettings key)
        {
            return _gameSettings.ContainsKey(key) && _gameSettings[key];
        }

        public void Save()
        {
            FileWriter.Save(this, GameDirectory.SettingsFilePath);
        }
    }
}
