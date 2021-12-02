using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Valtech_Task2_Ankh_Morpork_game_;

namespace AnkhMorpork.Models
{
    public sealed class AccountContext : IdentityDbContext<Player>
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
            if(!Database.EnsureCreated())
                Database.EnsureCreated();
        }
    }
}
