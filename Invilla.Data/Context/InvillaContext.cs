using Invilla.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Invilla.Data.Context
{
    public class InvillaContext : DbContext
    {
        
        public DbSet<FriendsEntity> Friends { get; set; }
        public DbSet<GamesEntity> Games { get; set; }
        public DbSet<LoansEntity> Loans { get; set; }
        public DbSet<LoginsEntity> Logins { get; set; }

        public DbSet<RolesEntity> Roles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;User ID=INDRA\dzapater;Initial Catalog=Invilla;Data Source=DZAPATER10");
        }

    }
}
