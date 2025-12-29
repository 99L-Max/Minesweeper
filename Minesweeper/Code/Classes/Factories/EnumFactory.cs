using System;
using System.Linq;

namespace Minesweeper
{
    static class EnumFactory
    {
        public static T[] GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToArray();
        }

        public static T[] GetValuesBySkip<T>(params T[] missingValues)
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Where(item => missingValues.Contains(item) == false).ToArray();
        }

        public static T GetRandomValue<T>()
        {
            var items = GetValues<T>();
            return items[GameRandom.Next(items.Length)];
        }

        public static int GetCount<T>()
        {
            return Enum.GetValues(typeof(T)).Length;
        }
    }
}
