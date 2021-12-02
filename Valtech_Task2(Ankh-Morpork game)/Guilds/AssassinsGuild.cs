using System;
using System.Collections.Generic;
using System.Linq;
using Valtech_Task2_Ankh_Morpork_game_.Data;
using Valtech_Task2_Ankh_Morpork_game_.Data.Models;
using Valtech_Task2_Ankh_Morpork_game_.Data.Repository;
using Valtech_Task2_Ankh_Morpork_game_.Service;

namespace Valtech_Task2_Ankh_Morpork_game_.Guilds
{
    public class AssassinsGuild : Guilds
    {
        private decimal Pay { get; set; }
        private readonly Repository _repository;
        public AssassinsGuild(AnkhMorporkGameContext context) : base("Assassin",
            "NIL VOLVPTI, SINE LVCRE (No Pay No Fun)")
        {
            this._repository = new(context);
        }
        public override void Action(Player player, AnkhMorporkGameContext context)
        {
            DisplayDifferentTextColor.DisplayBlueColorText("Someone wants to kill you! You have two options: Take(yes) contract or skip and die for free!\n");
            Console.Write("Enter your answer: ");
            player._answer = player.ReturnAnswer();
            if (player._answer.Equals("skip"))
            {
                player.IsKilled = true;
                DisplayDifferentTextColor.DisplayRedColorText("You was killed, coz assassin need money! Game over!");
            }
            else
            {
                var check = false;
                while (!check)
                {
                    check = CheckAssassinContract(player.Money, context);
                }
                player.LooseMoney(Pay);
            }
        }
        private bool CheckAssassinContract(decimal money, AnkhMorporkGameContext context)
        {
            var inputPay = string.Empty;
            decimal pay = 0;
            var checkNumber = false;
            IEnumerable<Assassins> listOfAssassinsEnumerable = new List<Assassins>();
            DisplayDifferentTextColor.DisplayBlueColorText("Write how much money do you want to give him: ");
            while (!listOfAssassinsEnumerable.Any())
            {
                while (inputPay == string.Empty || checkNumber == false)
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
                            DisplayDifferentTextColor.DisplayRedColorText(Convert.ToDecimal(inputPay) > money
                                ? $"\aYou don't have {pay} dollars, input less: "
                                : "\aEnter number more than zero: ");
                        }
                        checkNumber = false;
                    }
                }
                listOfAssassinsEnumerable = CheckAssassinOccupied(pay,context);
                if (!listOfAssassinsEnumerable.Any())
                    checkNumber = false;
            }
            Pay = pay;
            return true;
        }
        private IEnumerable<Assassins> CheckAssassinOccupied(decimal pay, AnkhMorporkGameContext context)
        {
            var notOccupiedAssassins = _repository.GetAssassinsEnumerable.Where(assassin => assassin.IsOccupied == false && (assassin.MinRange <= pay && pay <= assassin.MaxRange));
            var checkAssassinOccupied = notOccupiedAssassins as Assassins[] ?? notOccupiedAssassins.ToArray();
            for (var i = 0; i < checkAssassinOccupied.Length; ++i)
            {
                if(i == checkAssassinOccupied.Length - 1)
                    Console.Write(checkAssassinOccupied[i].Name);
                else
                    Console.Write(checkAssassinOccupied[i].Name + ", ");
            }
            switch (checkAssassinOccupied.Length)
            {
                case 1:
                    Console.WriteLine(" is free.");
                    break;
                case > 1:
                    Console.WriteLine(" are free. You take first one from the list");
                    break;
                default:
                    DisplayDifferentTextColor.DisplayRedColorText("\aAll assassins are occupied! Enter another amount of money: ");
                    break;
            }
            return checkAssassinOccupied;
        }
        public override string ToString() { return $"Guild: {Name} Slogan: {Slogan}"; }
    }
}