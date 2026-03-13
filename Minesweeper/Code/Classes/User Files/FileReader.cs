using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Minesweeper
{
    static class FileReader
    {
        public static Dictionary<TKey, TValue> GetDictionary<TKey, TValue>(byte[] resource)
        {
            var json = Encoding.UTF8.GetString(resource);
            return JsonConvert.DeserializeObject<Dictionary<TKey, TValue>>(json);
        }

        public static SettingsData GetSettingsOrDefault()
        {
            return GetObjectFromFile<SettingsData>(GameDirectory.SettingsFilePath);
        }

        public static StatisticsData GetStatisticsOrDefault()
        {
            return GetObjectFromFile<StatisticsData>(GameDirectory.StatisticsFilePath);
        }

        public static UserInterfaceData GetUserInterfaceDataOrDefault()
        {
            return GetObjectFromFile<UserInterfaceData>(GameDirectory.UserInterfaceDataFilePath);
        }

        public static bool TryOpenSaveFile(out MapCell[] cells, out int gameTimeInSeconds)
        {
            try
            {
                var jsonMap = File.ReadAllText(GameDirectory.MapFilePath);
                var jsonSeconds = File.ReadAllText(GameDirectory.GameTimeInSecondsFilePath);

                cells = JsonConvert.DeserializeObject<MapCell[]>(jsonMap);
                gameTimeInSeconds = JsonConvert.DeserializeObject<int>(jsonSeconds);
                return true;
            }
            catch (Exception)
            {
                cells = null;
                gameTimeInSeconds = default;
                return false;
            }
        }

        private static T GetObjectFromFile<T>(string path) where T : new()
        {
            try
            {
                var json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception)
            {
                return new T();
            }
        }
    }
}