
namespace Valtech_Task2_Ankh_Morpork_game_.Guilds
{
    public class ThievesGuild : Guilds
    {
        public static byte TheftLimit { get; set; } = 6;
        public static byte Pay { get; } = 10;
        private ThievesGuild() : base("Thieve", "ACVTVS ID VERBERAT (Whistle Fast)") { }
        public override string ToString() { return $"Guild: {Name} Slogan: {Slogan}"; }
    }
}
