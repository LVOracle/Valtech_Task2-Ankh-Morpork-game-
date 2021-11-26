using System;
using System.Linq;
using Valtech_Task2_Ankh_Morpork_game_.Data;
using Valtech_Task2_Ankh_Morpork_game_.Data.Repository;
using Valtech_Task2_Ankh_Morpork_game_.Guilds.GuildMembers;
using Valtech_Task2_Ankh_Morpork_game_.Service;

namespace Valtech_Task2_Ankh_Morpork_game_.Guilds
{
    public class AssassinsGuild : Guilds
    {
        private readonly Repository _repository;
        public AssassinsGuild(AnkhMorporkGameContext _context) : base("Assassin",
            "NIL VOLVPTI, SINE LVCRE (No Pay No Fun)")
        {
            this._repository = new(_context);
        }
        public override void Action(Player Player)
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
                    Console.WriteLine("(" + (i + 1) + ")" + _repository.GetAssassinsEnumerable.ElementAt(i).Name);
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
        private bool CheckAssassinContract()
        {
            string number = string.Empty;
            bool checkNumber = true;
            while (checkNumber)
            {
                while (number.Length != 1)
                {
                    number = Console.ReadLine();
                    if (number != null && number.Length != 1)
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
        public override string ToString() { return $"Guild: {Name} Slogan: {Slogan}"; }
    }
}