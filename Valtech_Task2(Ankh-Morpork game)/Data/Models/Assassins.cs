using System;

namespace Valtech_Task2_Ankh_Morpork_game_.Guilds.GuildMembers
{
    public class Assassins 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxRange { get; set; }
        public int MinRange { get; set; }
        public bool IsOccupied { get; set; }
        public override string ToString() { return Name; }
    }
}
