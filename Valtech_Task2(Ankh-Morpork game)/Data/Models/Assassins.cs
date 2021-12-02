namespace Valtech_Task2_Ankh_Morpork_game_.Data.Models
{
    public class Assassins 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal MaxRange { get; set; }
        public decimal MinRange { get; set; }
        public bool IsOccupied { get; set; }
        public override string ToString() { return Name; }
    }
}
