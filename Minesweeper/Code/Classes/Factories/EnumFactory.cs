using System;
using System.Linq;

namespace Minesweeper
{
    static class EnumFactory
    {
        public static T[] GetValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToArray();
        }

        public static T[] GetValuesBySkip<T>(params T[] missingValues) where T : Enum
        {
            return GetValues<T>().Where(item => missingValues.Contains(item) == false).ToArray();
        }

        public static T GetRandomValue<T>() where T : Enum
        {
            var items = GetValues<T>();
            return items[GameRandom.Next(items.Length)];
        }

        public static int GetCount<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Length;
        }
    }
}
