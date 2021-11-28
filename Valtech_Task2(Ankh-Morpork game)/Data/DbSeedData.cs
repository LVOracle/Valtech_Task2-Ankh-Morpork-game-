using System.Collections.Generic;
using Valtech_Task2_Ankh_Morpork_game_.Data;
using Valtech_Task2_Ankh_Morpork_game_.Guilds.GuildMembers;

namespace Valtech_Task2_Ankh_Morpork_game_
{
    public static class DbSeedData
    {
        public static void SeedData(AnkhMorporkGameContext context)
        {
            context.Assassins.AddRange(new List<Assassins>
            {
                new Assassins { Name = "Knife", MinRange = 15, MaxRange = 30, IsOccupied = false},
                new Assassins { Name = "Sword", MinRange = 10,  MaxRange = 20, IsOccupied = true},
                new Assassins { Name = "Star", MinRange = 7, MaxRange = 12, IsOccupied = false},
                new Assassins { Name = "Axe", MinRange = 15, MaxRange = 19, IsOccupied = true},
                new Assassins { Name = "Gun", MinRange = 4, MaxRange = 12, IsOccupied = true},
                new Assassins { Name = "Ranger", MinRange = 29, MaxRange = 45, IsOccupied = false},
                new Assassins { Name = "Dodick", MinRange = 15, MaxRange = 22, IsOccupied = false},
                new Assassins { Name = "RedBorsh", MinRange = 18, MaxRange = 27, IsOccupied = true}
            });

            context.Beggars.AddRange(new List<Beggars>
            {
                new Beggars { Name = "Twitcher", GiveMoney = 3},
                new Beggars { Name = "Drooler", GiveMoney = 2},
                new Beggars { Name = "Dribbler", GiveMoney = 1},
                new Beggars { Name = "Mumbler", GiveMoney = 1},
                new Beggars { Name = "Mutterer", GiveMoney = 0.9m},
                new Beggars { Name = "Walking-Along-Shouters", GiveMoney = 0.8m},
                new Beggars { Name = "Demanders of a Chip", GiveMoney = 0.6m},
                new Beggars { Name = "People Who Call Other People Jimmy", GiveMoney = 0.5m},
                new Beggars { Name = "People Who Need Eightpence For A Meal", GiveMoney = 0.08m},
                new Beggars { Name = "People Who Need Tuppence For A Cup Of Tea", GiveMoney = 0.02m},
                new Beggars { Name = "People With Placards Saying \"Why lie? I need a beer.\"", GiveMoney = 0},
            });

            context.Fools.AddRange(new List<Fools>
            {
                new Fools { Name = "Muggins", TakeMoney = 0.5m},
                new Fools { Name = "Gull", TakeMoney = 1},
                new Fools { Name = "Dupe", TakeMoney = 2},
                new Fools { Name = "Butt", TakeMoney = 3},
                new Fools { Name = "Fool", TakeMoney = 5},
                new Fools { Name = "Tomfool", TakeMoney = 6},
                new Fools { Name = "Stupid fool", TakeMoney = 7},
                new Fools { Name = "Arch fool", TakeMoney = 8},
                new Fools { Name = "Complete fool", TakeMoney = 10},
            });

            context.Thieves.AddRange(new List<Thieves>
            {
                new Thieves(){Name = "Brandy"},
                new Thieves(){Name = "Stocky"},
                new Thieves(){Name = "Falcon"}
            });

            context.SaveChangesAsync();
        }
    }
}

