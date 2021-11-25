
namespace Valtech_Task2_Ankh_Morpork_game_.Guilds
{
    public class AssassinsGuild : Guilds
    {
        public AssassinsGuild() : base("Assassin", "NIL VOLVPTI, SINE LVCRE (No Pay No Fun)") {}
        public override string ToString() { return $"Guild: {Name} Slogan: {Slogan}"; }
    }
}