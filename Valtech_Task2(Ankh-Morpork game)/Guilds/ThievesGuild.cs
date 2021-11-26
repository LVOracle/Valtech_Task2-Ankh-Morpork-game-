
using Valtech_Task2_Ankh_Morpork_game_.Data;
using Valtech_Task2_Ankh_Morpork_game_.Data.Repository;
using Valtech_Task2_Ankh_Morpork_game_.Service;

namespace Valtech_Task2_Ankh_Morpork_game_.Guilds
{
    public class ThievesGuild : Guilds
    {
        private readonly Repository _repository;
        public static byte TheftLimit { get; set; } = 6;
        public static byte Pay { get; } = 10;
        public ThievesGuild(AnkhMorporkGameContext context) : base("Thieve", "ACVTVS ID VERBERAT (Whistle Fast)")
        {
            _repository = new(context);
        }
        public override void Action(Player Player)
        {
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
        public override string ToString() { return $"Guild: {Name} Slogan: {Slogan}"; }
    }
}
