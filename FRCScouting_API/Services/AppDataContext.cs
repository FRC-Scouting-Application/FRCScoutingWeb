using FRCScouting_API.Models;
using Microsoft.EntityFrameworkCore;

namespace FRCScouting_API.Services
{
    public class AppDataContext : DbContext
    {
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<Scout> Scouts { get; set; }
        public virtual DbSet<Note> Notes { get; set; }


        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasKey(x => x.Key);

            modelBuilder.Entity<Team>()
                .HasKey(x => x.Key);
              
            modelBuilder.Entity<Event>()
                .HasKey(x => x.Key);

            modelBuilder.Entity<Template>()
                .HasKey(x => new { x.Id, x.Version });

            modelBuilder.Entity<Scout>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Note>()
                .HasKey(x => x.Id);
        }
    }
}
