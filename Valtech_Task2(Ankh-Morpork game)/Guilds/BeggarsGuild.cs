using System.Linq;
using Valtech_Task2_Ankh_Morpork_game_.Data;
using Valtech_Task2_Ankh_Morpork_game_.Data.Repository;
using Valtech_Task2_Ankh_Morpork_game_.Service;

namespace Valtech_Task2_Ankh_Morpork_game_.Guilds
{
    public class BeggarsGuild : Guilds
    {
        private readonly Repository _repository;
        public BeggarsGuild(AnkhMorporkGameContext context) : base("Beggar",
            "MONETA SVPERVACANEA, MAGISTER (Coin Svpervacanea, Magister)")
        {
            _repository = new(context);
        } 
        public override void Action(Player Player, AnkhMorporkGameContext context)
        {
            var number = RandomGenerate.GetRandom(1, _repository.GetBeggarsEnumerable.Count() + 1);
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
                Player.LooseMoney(beggar.GiveMoney);
            }
        }
        public override string ToString() { return $"Guild: {Name} Slogan: {Slogan}"; }
    }
}
