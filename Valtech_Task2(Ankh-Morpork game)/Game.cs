using System;
using System.Linq;
using System.Threading;
using Valtech_Task2_Ankh_Morpork_game_.Data;
using Valtech_Task2_Ankh_Morpork_game_.Data.Repository;
using Valtech_Task2_Ankh_Morpork_game_.Guilds;
using Valtech_Task2_Ankh_Morpork_game_.Guilds.GuildMembers;
using Valtech_Task2_Ankh_Morpork_game_.Service;

namespace Valtech_Task2_Ankh_Morpork_game_
{
    public class Game
    {
        public int Steps { get; private set; } = 1;
        public string Name { get; private set; } = "Ankh Morpork Game";
        private Player Player { get; set; }

        private Random _generateRandom = new();

        private AnkhMorporkGameContext _context;

        private Repository _repository;

        public Game(AnkhMorporkGameContext context)
        {
            this._context = context;
            _repository = new(context);
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
                    guildRandom = _generateRandom.Next(0,5);
                }while (ThievesGuild.TheftLimit == 0 && guildRandom == 3);
                switch (guildRandom)
                {
                    case 0:
                        AssassinAction();
                        break;
                    case 1:
                        BeggarsAction();
                        break;
                    case 2:
                        FoolsAction();
                        break;
                    case 3:
                        ThievesAction();
                        break;
                    case 4:
                        FoolsAction();
                        break;
                }
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
                Thread.Sleep(2500);
            }
        }
        private void AssassinAction()
        {
            DisplayDifferentTextColor.DisplayBlueColorText("Some one want to kill you! You have two options: Take(yes) contract 15$ cost or skip and die for free!");
            Console.WriteLine();
            Console.Write("Enter your answer: ");
            Player._answer = Player.ReturnAnswer();
            if (Player._answer.Equals("skip"))
            {
                Player.IsKilled = true;
                DisplayDifferentTextColor.DisplayRedColorText("You was killed, coz assassin need money! Game over!");
            }
            else
            {
                DisplayDifferentTextColor.DisplayBlueColorText("You must choose a assassin from the list:\n");
                for (int i = 0; i < _repository.GetAssassinsEnumerable.Count(); ++i)
                {
                    Console.WriteLine("("+(i+1)+")"+_repository.GetAssassinsEnumerable.ElementAt(i).Name);
                }
                DisplayDifferentTextColor.DisplayBlueColorText("Write the number of a certain assassin: ");
                bool check = false;
                while (!check)
                {
                    check = CheckAssassinContract();
                }
                Player.Money = Player.Money - 15;
            }
        }
        private void BeggarsAction()
        {
            var number = _generateRandom.Next(1, _repository.GetBeggarsEnumerable.Count() + 1);
            var beggar = _repository.GetBeggarsEnumerable.FirstOrDefault(p => p.Id == number);
            DisplayDifferentTextColor.DisplayBlueColorText($"You met a beggar by name {beggar.Name} you must give him {beggar.GiveMoney} dollars!\nDo it(yes) or die(skip): ");
            Player._answer = Player.ReturnAnswer();
            if (Player._answer.Equals("skip"))
            {
                Player.IsKilled = true;
                DisplayDifferentTextColor.DisplayRedColorText("You was killed by beggars! Game over!");
            }
            else
            {
                DisplayDifferentTextColor.DisplayRedColorText($"You gave {beggar.GiveMoney} dollars!");
                Player.Money -= beggar.GiveMoney;
            }
        }
        private void FoolsAction()
        {
            var number = _generateRandom.Next(1, _repository.GetFoolsEnumerable.Count() + 1);
            var fool = _repository.GetFoolsEnumerable.FirstOrDefault(p => p.Id == number);
            DisplayDifferentTextColor.DisplayBlueColorText($"You met a fool by name {fool.Name} he gives you job to earn {fool.TakeMoney} dollars! Take it(yes) or you stupid(skip): ");
            Player._answer = Player.ReturnAnswer();
            if (Player._answer.Equals("skip"))
            {
                DisplayDifferentTextColor.DisplayRedColorText("You so stupid man! It only one way to have money in this game!");
            }
            else
            {
                DisplayDifferentTextColor.DisplayGreenColorText($"You earn {fool.TakeMoney} dollars!");
                Player.Money += fool.TakeMoney;
            }
        }
        private void ThievesAction()
        {
            if (ThievesGuild.TheftLimit == 0)
                return;
            --ThievesGuild.TheftLimit;
            Player.Money = Player.Money - ThievesGuild.Pay;
            DisplayDifferentTextColor.DisplayBlueColorText("You met a thief and 10 dollars were stolen from you! You agree?(yes/skip): ");
            Player._answer = Player.ReturnAnswer();
            if (Player._answer.Equals("skip"))
            {
                DisplayDifferentTextColor.DisplayRedColorText("Good luck! I don't care!");
            }
            else
            {
                DisplayDifferentTextColor.DisplayRedColorText("Take care of your pockets!");
            }
        }
        private bool CheckAssassinContract()
        {
            string number = string.Empty;
            bool checkNumber = true;
            while (checkNumber)
            {
                while (number.Length != 1)
                {
                    number = Console.ReadLine();
                    if(number != null && number.Length != 1)
                        DisplayDifferentTextColor.DisplayRedColorText($"\aInput assassin from 1-{_repository.GetAssassinsEnumerable.Count()}: ");
                }

                if (Convert.ToInt32(number) <= 0 ||
                    Convert.ToInt32(number) > _repository.GetAssassinsEnumerable.Count())
                    checkNumber = false;
                else
                {
                    Assassins assassin = (Assassins)_repository.GetAssassinsEnumerable.FirstOrDefault(p => p.Id == Convert.ToInt32(number));
                    return CheckAssassinOccupied(assassin);
                }
            }
            return false;
        }
        private bool CheckAssassinOccupied(Assassins a)
        {
            if (a.IsOccupied == true && a.MinRange < 15)
            {
                DisplayDifferentTextColor.DisplayGreenColorText($"{a.Name} is free!");
                return true;
            }
            else
            {
                DisplayDifferentTextColor.DisplayRedColorText($"{a.Name} is occupied! Choose another assassin: ");
                return false;
            }
        }
        private void RegisterPlayer()
        {
            Console.Write("What's your name bro: ");
            string name = Console.ReadLine();
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
            Thread.Sleep(5000);
            Moves();
        }
    }
}
