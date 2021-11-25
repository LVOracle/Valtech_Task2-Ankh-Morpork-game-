using System.Collections.Generic;
using Valtech_Task2_Ankh_Morpork_game_.Guilds.GuildMembers;

namespace Valtech_Task2_Ankh_Morpork_game_.Guilds
{
    public class FoolsGuild : Guilds
    {
        private FoolsGuild( ) : base("Fool", "DICO, DICO, DICO ( (=Say Say Say=) )") { }
        public override string ToString() { return $"Guild: {Name} Slogan: {Slogan}"; }
    }
}