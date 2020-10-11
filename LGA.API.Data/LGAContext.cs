using LGA.API.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LGA.API.Data
{
    public class LGAContext : DbContext
    {
        public LGAContext(DbContextOptions options) : base(options) { }
        public DbSet<State> States { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<ScoreDetail> ScoreDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}

