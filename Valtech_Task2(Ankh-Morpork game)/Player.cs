
namespace Valtech_Task2_Ankh_Morpork_game_
{
    public class Player
    {
        public string Name { get; set; }
        public decimal Money { get; set; }
        public bool IsKilled { get; set; }
        public Player(string name)
        {
            Name = name;
            Money = 100m;
            IsKilled = false;
        }
        public override string ToString() { return Name; }
    }
}
