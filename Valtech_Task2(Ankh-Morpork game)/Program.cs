using System;
using Microsoft.EntityFrameworkCore;
using Valtech_Task2_Ankh_Morpork_game_.Data;

namespace Valtech_Task2_Ankh_Morpork_game_
{
    class Program
    {
        static void Main(string[] args)
        {
            var oBuilder = new DbContextOptions<AnkhMorporkGameContext>();
            var instance = new AnkhMorporkGameContext(oBuilder);
            try
            {
                DbSeedData.SeedData(instance);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Game game = new(instance);
            game.LaunchGame();
        }
    }
}
