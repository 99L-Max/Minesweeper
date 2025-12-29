using System;

namespace Minesweeper
{
    static class GameRandom
    {
        private static readonly Random s_random = new Random();

        public static int Next(int maxValue = int.MaxValue) => s_random.Next(maxValue);
    }
}
