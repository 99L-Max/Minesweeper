using System;
using System.IO;

namespace Minesweeper
{
    static class GameDirectory
    {
        static GameDirectory()
        {
            SavingPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\{typeof(Program).Namespace}";
        }

        public static string SavingPath { get; }
        public static string SettingsFilePath => $@"{SavingPath}\Settings.json";
        public static string StatisticsFilePath => $@"{SavingPath}\Statistics.json";
        public static string MapFilePath => $@"{SavingPath}\Map.json";
        public static string GameTimeInSecondsFilePath => $@"{SavingPath}\GameTimeInSeconds.json";
        public static string UserInterfaceDataFilePath => $@"{SavingPath}\FormData.json";

        public static void CreateSaveDirectory()
        {
            Directory.CreateDirectory(SavingPath);
        }
    }
}
