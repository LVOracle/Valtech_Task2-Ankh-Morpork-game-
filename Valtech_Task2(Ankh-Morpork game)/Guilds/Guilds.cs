
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
        public abstract void Action(Player Player);
    }
}
