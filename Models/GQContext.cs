using Microsoft.EntityFrameworkCore;

namespace General_Quarters.Models
{
    public class GQContext : DbContext
    {
        public GQContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get;set;}
        public DbSet<Profile> Profiles {get;set;}
    }
}