using Microsoft.EntityFrameworkCore;
using Valtech_Task2_Ankh_Morpork_game_.Guilds.GuildMembers;

namespace Valtech_Task2_Ankh_Morpork_game_.Data
{
    public sealed class AnkhMorporkGameContext : DbContext
    {
        public DbSet<Assassins> Assassins { get; set; }
        public DbSet<Beggars> Beggars { get; set; }
        public DbSet<Thieves> Thieves { get; set; }
        public DbSet<Fools> Fools { get; set; }
        public AnkhMorporkGameContext(DbContextOptions<AnkhMorporkGameContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=UA02638;Database=AnkhMorporkGameDB;Trusted_Connection=True;"); //.\SQLEXPRESS UA02638
        }
    }
}