using System;

namespace Valtech_Task2_Ankh_Morpork_game_
{
    public static class RandomGenerate
    {
        private static readonly Random Random = new();
        public static int GetRandom(int start, int finish)
        {
            var number = Random.Next(start, finish);
            return number;
        }
    }
}
