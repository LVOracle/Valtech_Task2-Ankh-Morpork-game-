
using System;
using Valtech_Task2_Ankh_Morpork_game_.Service;

namespace Valtech_Task2_Ankh_Morpork_game_
{
    public class Player
    {
        public string Name { get; set; }
        public decimal Money { get; set; }
        public bool IsKilled { get; set; }
        public Player(string name)
        {
            Name = name;
            Money = 100m;
            IsKilled = false;
        }
        public static string _answer = string.Empty;
        public static string ReturnAnswer()
        {
            string answer;
            while (true)
            {
                answer = Console.ReadLine()?.ToLower();
                if (answer != null && (answer.Equals("yes") || answer.Equals("skip"))) break;
                else DisplayDifferentTextColor.DisplayRedColorText("\aError! Write only \'yes\' or \'skip\'!");
            }
            return answer;
        }
        public bool CheckMoneyBalance()
        {
            if (Money <= 0)
                return false;
            return true;
        }
        public override string ToString() { return Name; }
    }
}
