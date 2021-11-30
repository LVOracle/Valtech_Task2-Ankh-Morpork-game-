using System;
using System.Linq;
using System.Threading;
using Valtech_Task2_Ankh_Morpork_game_.Data;
using Valtech_Task2_Ankh_Morpork_game_.Guilds;
using Valtech_Task2_Ankh_Morpork_game_.Service;

namespace Valtech_Task2_Ankh_Morpork_game_
{
    public class Game
    {
        public int Steps { get; private set; } = 1;
        public string Name { get; private set; } = "Ankh Morpork Game";
        private Player Player { get; set; }
        private int Length { get; set; }
        private AnkhMorporkGameContext Context { get; }
        public Game(AnkhMorporkGameContext context)
        {
            Context = context;
            Length = Guilds.Guilds.GetAllGuilds(context).Length;
        }
        private void Moves()
        {
            while (Player.IsKilled == false)
            {
                Console.Clear();
                Console.WriteLine($"Step is {Steps} | Your balance is {Player.Money}$");
                int guildRandom;
                do
                {
                    guildRandom = RandomGenerate.GetRandom(0,Length);
                }while (ThievesGuild.TheftLimit == 0 && guildRandom == 3);

                var someGuild = Guilds.Guilds.GetAllGuilds(Context).ElementAt(guildRandom);
                someGuild.Action(Player, Context);

                if (!Player.CheckMoneyBalance())
                {
                    DisplayDifferentTextColor.DisplayRedColorText("Your pockets are empty! You loose! Game over!");
                    Player.IsKilled = true; 
                }
                if (Player.Money >= 200)
                {
                    DisplayDifferentTextColor.DisplayGreenColorText("Your win this! Congratulation!");
                    break;
                }
                ++Steps;
                Player._answer = string.Empty;
                Thread.Sleep(3000);
            }
        }
        private void RegisterPlayer()
        {
            Console.Write("What's your name bro: ");
            var name = Console.ReadLine();
            Player = new Player(name);
        }
        private void DisplayRules()
        {
            DisplayDifferentTextColor.DisplayGreenColorText($"\t\t\t\tWelcome {Player.Name} to the {Name}! Some rules for you:\n");
            Console.WriteLine("\t\t\t\t\t     ---Your balance of money is 100$---");
            Console.WriteLine("\t\t\t\tYou randomly meet one of the four guilds over and over again.");
            Console.WriteLine("\t\t\tYou can select an action between 2 options(play or skip) depending on the guild type.");
            DisplayDifferentTextColor.DisplayGreenColorText("\t\t\t\t\tYou win if you earn 200$! Wish you good luck!\n");
        }
        public void LaunchGame()
        {
            RegisterPlayer();
            DisplayRules();
            Thread.Sleep(7000);
            Moves();
        }
    }
}
