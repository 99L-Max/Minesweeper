using Minesweeper.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Minesweeper
{
    enum GameSettings
    {
        IsShowAnimation,
        IsPlaySounds,
        IsContinueSavedGame,
        IsSaveGameExiting,
        IsShowQuestionMarks,
    }

    enum Level { Easy, Medium, Hard, Special }

    enum Theme { Blue, Green, Purple }

    class SettingsData
    {
        public const int MinWidthMap = 9;
        public const int MinHeightMap = 9;
        public const int MinCountMines = 10;
        public const int MaxWidthMap = 30;
        public const int MaxHeightMap = 24;

        private readonly Dictionary<GameSettings, bool> _settings;

        public static readonly ReadOnlyDictionary<Level, Size> DictionaryMapSize;
        public static readonly ReadOnlyDictionary<Level, int> DictionaryCountMines;
        public static readonly ReadOnlyDictionary<Level, string> DictionaryLevelTitles;

        public Theme Theme { get; private set; }
        public Level Level { get; private set; }
        public Size MapSize { get; private set; }
        public int CountMines { get; private set; }
        public int SpecialWidthMap { get; private set; }
        public int SpecialHeightMap { get; private set; }
        public int SpecialCountMines { get; private set; }
        public bool IsRandomTheme { get; private set; }

        static SettingsData()
        {
            var levelTitles = JsonManager.GetDictionary<Level, string>(Resources.Level_Titles);

            var countMines = new Dictionary<Level, int>()
            {
                { Level.Easy, 10 },
                { Level.Medium, 40 },
                { Level.Hard, 99 },
            };

            var mapSize = new Dictionary<Level, Size>()
            {
                { Level.Easy, new Size(MinWidthMap, MinHeightMap) },
                { Level.Medium, new Size(16, 16) },
                { Level.Hard, new Size(MaxWidthMap, 16) },
            };

            DictionaryCountMines = new ReadOnlyDictionary<Level, int>(countMines);
            DictionaryMapSize = new ReadOnlyDictionary<Level, Size>(mapSize);
            DictionaryLevelTitles = new ReadOnlyDictionary<Level, string>(levelTitles);
        }

        public SettingsData(string path)
        {
            Level = (Level)Settings.Default.Level;
            Theme = (Theme)Settings.Default.Theme;
            IsRandomTheme = Settings.Default.IsRandomTheme;

            SpecialWidthMap = Settings.Default.SpecialWidthMap;
            SpecialHeightMap = Settings.Default.SpecialHeightMap;
            SpecialCountMines = Settings.Default.SpecialCountMines;

            SetMapData(Level, SpecialWidthMap, SpecialHeightMap, SpecialCountMines);

            var defaultSettings = JsonManager.GetDictionary<GameSettings, bool>(Resources.Settings_Default);

            try
            {
                using (var reader = new StreamReader(path + @"\Settings.json"))
                {
                    var keys = Enum.GetValues(typeof(GameSettings)).Cast<GameSettings>();
                    var jString = reader.ReadToEnd();

                    _settings = JsonConvert.DeserializeObject<Dictionary<GameSettings, bool>>(jString);

                    foreach (var key in keys)
                        if (!_settings.ContainsKey(key))
                            _settings.Add(key, defaultSettings[key]);
                }
            }
            catch (Exception)
            {
                _settings = defaultSettings;
            }

            Sound.IsPlaySounds = _settings[GameSettings.IsPlaySounds];
        }

        public void SetTheme(Theme theme, bool isRandomTheme)
        {
            IsRandomTheme = isRandomTheme;

            if (IsRandomTheme)
            {
                var themes = Enum.GetValues(typeof(Theme)).Cast<Theme>().ToArray();
                Theme = themes[(new Random()).Next(themes.Length)];
            }
            else
                Theme = theme;
        }

        public void SetMapData(Level level, int widthMap, int heightMap, int countMines)
        {
            Level = level;

            if (Level == Level.Special)
            {
                MapSize = new Size(widthMap, heightMap);
                CountMines = countMines;

                SpecialWidthMap = widthMap;
                SpecialHeightMap = heightMap;
                SpecialCountMines = countMines;
            }
            else
            {
                MapSize = DictionaryMapSize[level];
                CountMines = DictionaryCountMines[level];
            }
        }

        public void SetSettings(GameSettings key, bool value)
        { 
            _settings[key] = value;

            if (key == GameSettings.IsPlaySounds)
                Sound.IsPlaySounds = value;
        }

        public bool GetSettings(GameSettings key) =>
            _settings[key];

        public static string GetLevelDescription(Level level)
        {
            if (level == Level.Special)
                return DictionaryLevelTitles[level];

            return $"{DictionaryLevelTitles[level]}\n{DictionaryCountMines[level]} мин\n поле {DictionaryMapSize[level].Width} x {DictionaryMapSize[level].Height} ячеек";
        }

        public static decimal MaxCountMines(decimal countCells) =>
            Math.Round(0.94m * countCells - 8.91m);

        public void Save(string pathSave)
        {
            Settings.Default.Level = (int)Level;
            Settings.Default.Theme = (int)Theme;
            Settings.Default.IsRandomTheme = IsRandomTheme;

            Settings.Default.SpecialWidthMap = SpecialWidthMap;
            Settings.Default.SpecialHeightMap = SpecialHeightMap;
            Settings.Default.SpecialCountMines = SpecialCountMines;

            Settings.Default.Save();

            var data = JsonConvert.SerializeObject(_settings);
            File.WriteAllText(pathSave + @"\Settings.json", data);
        }
    }
}
