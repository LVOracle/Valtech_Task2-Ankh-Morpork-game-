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
        private decimal Pay { get; set; }
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
                bool check = false;
                while (!check)
                {
                    check = CheckAssassinContract(Player.Money);
                }
                Player.LooseMoney(Pay);
            }
        }
        private bool CheckAssassinContract(decimal money)
        {
            string inputPay = string.Empty;
            string inputNumber = string.Empty;
            decimal pay = 0;
            int number = 0;
            bool checkNumber = false;
            DisplayDifferentTextColor.DisplayBlueColorText("Write how much money do you what to give him: ");
            while (inputPay == String.Empty || checkNumber == false) 
            {
                inputPay = Console.ReadLine();
                checkNumber = decimal.TryParse(inputPay, out pay);
                if (checkNumber && Convert.ToDecimal(inputPay) > 0 && Convert.ToDecimal(inputPay) < money)
                    break;
                else
                {
                    if (!checkNumber)
                        DisplayDifferentTextColor.DisplayRedColorText("\aEnter number please: ");
                    else
                    {
                        if(Convert.ToDecimal(inputPay) > money)
                            DisplayDifferentTextColor.DisplayRedColorText($"\aYou don't have {pay} dollars, input less: ");
                        else
                            DisplayDifferentTextColor.DisplayRedColorText("\aEnter number more than zero: ");
                        checkNumber = false;
                    }
                }
            }
            DisplayDifferentTextColor.DisplayBlueColorText("Write the number of a certain assassin: ");
            while (checkNumber)
            {
                while (inputNumber == String.Empty || checkNumber == false)
                {
                    inputNumber = Console.ReadLine();
                    checkNumber = int.TryParse(inputNumber, out number);
                    if (checkNumber && (Convert.ToDecimal(inputNumber) > 0 && Convert.ToDecimal(inputNumber) <= _repository.GetAssassinsEnumerable.Count()))
                        break;
                    else
                    {
                        if (!checkNumber)
                            DisplayDifferentTextColor.DisplayRedColorText("\aEnter number please: ");
                        else
                        {
                            DisplayDifferentTextColor.DisplayRedColorText($"\aEnter number more 1-{_repository.GetAssassinsEnumerable.Count()}: ");
                            checkNumber = false;
                        }
                    }
                }
                Assassins assassin = _repository.GetAssassinsEnumerable.FirstOrDefault(p => p.Id == Convert.ToInt32(inputNumber));
                    return CheckAssassinOccupied(assassin, pay);
            }
            return false;
        }
        private bool CheckAssassinOccupied(Assassins a, decimal pay)
        {
            if (a.IsOccupied == true && pay >= a.MinRange)
            {
                DisplayDifferentTextColor.DisplayGreenColorText($"{a.Name} is free!");
                Pay = pay;
                return true;
            }
            else
            {
                DisplayDifferentTextColor.DisplayRedColorText(!a.IsOccupied
                    ? $"{a.Name} is occupied! Choose another assassin!\n"
                    : $"{a.Name} need more money to write a contract with you!\n");
                return false;
            }
        }
        public override string ToString() { return $"Guild: {Name} Slogan: {Slogan}"; }
    }
}