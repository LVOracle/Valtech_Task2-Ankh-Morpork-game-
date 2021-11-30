
using Valtech_Task2_Ankh_Morpork_game_.Data;
using Valtech_Task2_Ankh_Morpork_game_.Data.Repository;

namespace Valtech_Task2_Ankh_Morpork_game_.Guilds
{
    public abstract class Guilds
    {
        protected string Name { get; }
        protected string Slogan { get; }
        protected Guilds(string name, string slogan)
        {
            Name = name;
            Slogan = slogan;
        }
        public abstract void Action(Player Player, AnkhMorporkGameContext context);
        public static Guilds[] GetAllGuilds(AnkhMorporkGameContext context)
        {
            Guilds[] allGuildsArray = new Guilds[]
            {
                new AssassinsGuild(context), new BeggarsGuild(context),new FoolsGuild(context),new ThievesGuild(context)
            };
            return allGuildsArray;
        }
    }
}
