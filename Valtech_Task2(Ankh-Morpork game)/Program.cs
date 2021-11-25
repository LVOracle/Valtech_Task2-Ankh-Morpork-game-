using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Valtech_Task2_Ankh_Morpork_game_.Data;
using Valtech_Task2_Ankh_Morpork_game_.Data.Repository;

namespace Valtech_Task2_Ankh_Morpork_game_
{
    class Program
    {
        static void Main(string[] args)
        {
            var oBuilder = new DbContextOptions<AnkhMorporkGameContext>();
            var instance = new AnkhMorporkGameContext(oBuilder);
            DbSeedData.SeedData(instance);

            Game game = new(instance);
            game.LaunchGame();
        }
    }
}
