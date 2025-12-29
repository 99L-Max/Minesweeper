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
            try
            {
                var path = GameDirectory.SettingsFilePath;
                var json = File.ReadAllText(path);

                return JsonConvert.DeserializeObject<SettingsData>(json);
            }
            catch (Exception)
            {
                return new SettingsData();
            }
        }

        public static StatisticsData GetStatisticsOrDefault()
        {
            try
            {
                var path = GameDirectory.StatisticsFilePath;
                var json = File.ReadAllText(path);

                return JsonConvert.DeserializeObject<StatisticsData>(json);
            }
            catch (Exception)
            {
                return new StatisticsData();
            }
        }

        public static UserInterfaceData GetUserInterfaceDataOrDefault()
        {
            try
            {
                var path = GameDirectory.UserInterfaceDataFilePath;
                var json = File.ReadAllText(path);

                return JsonConvert.DeserializeObject<UserInterfaceData>(json);
            }
            catch (Exception)
            {
                return new UserInterfaceData();
            }
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
    }
}