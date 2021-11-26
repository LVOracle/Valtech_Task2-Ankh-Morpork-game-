using System.Linq;
using Valtech_Task2_Ankh_Morpork_game_.Data;
using Valtech_Task2_Ankh_Morpork_game_.Data.Repository;
using Valtech_Task2_Ankh_Morpork_game_.Service;

namespace Valtech_Task2_Ankh_Morpork_game_.Guilds
{
    public class FoolsGuild : Guilds
    {
        private readonly Repository _repository;
        public FoolsGuild(AnkhMorporkGameContext context) : base("Fool", "DICO, DICO, DICO ( (=Say Say Say=) )")
        {
            _repository = new(context);

        }
        public override void Action(Player Player)
        {
            var number = RandomGenerate.GetRandom(1, _repository.GetFoolsEnumerable.Count() + 1);
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
                Player.GetMoney(fool.TakeMoney);
            }
        }
        public override string ToString() { return $"Guild: {Name} Slogan: {Slogan}"; }
    }
}