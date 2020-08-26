using Microsoft.EntityFrameworkCore;

namespace General_Quarters.Models
{
    public class GQContext : DbContext
    {
        public GQContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get;set;}
        public DbSet<Game> Games {get;set;}
        public DbSet<JoinGame> JoinedGames {get;set;}
        public DbSet<Profile> Profiles {get;set;}
    }
}