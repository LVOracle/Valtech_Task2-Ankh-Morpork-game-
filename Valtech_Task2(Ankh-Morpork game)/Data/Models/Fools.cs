
namespace Valtech_Task2_Ankh_Morpork_game_.Guilds.GuildMembers
{
    public class Fools 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TakeMoney { get; set; }
        public override string ToString() { return Name; }
    }
}
