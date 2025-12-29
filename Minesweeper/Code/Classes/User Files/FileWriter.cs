using Newtonsoft.Json;
using System.IO;

namespace Minesweeper
{
    static class FileWriter
    {
        public static void Save(object data, string path)
        {
            var json = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, json);
        }

        public static void DeleteSavedGame()
        {
            Delete(GameDirectory.MapFilePath);
            Delete(GameDirectory.GameTimeInSecondsFilePath);
        }

        private static void Delete(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
