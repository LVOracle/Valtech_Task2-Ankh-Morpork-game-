
namespace Valtech_Task2_Ankh_Morpork_game_.Guilds.GuildMembers
{
    public class Beggars
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal GiveMoney { get; set; }
        public override string ToString() { return Name; }
    }
}
