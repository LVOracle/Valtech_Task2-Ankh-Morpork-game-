using System.Collections.Generic;
using Valtech_Task2_Ankh_Morpork_game_.Guilds.GuildMembers;

namespace Valtech_Task2_Ankh_Morpork_game_.Guilds
{
    public class BeggarsGuild : Guilds
    {
        private BeggarsGuild() : base("Beggar", "MONETA SVPERVACANEA, MAGISTER (Coin Svpervacanea, Magister)") { }
        public override string ToString() { return $"Guild: {Name} Slogan: {Slogan}"; }
    }
}
