using Football.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Football.Api.Repositories
{
    public class FootballDbContext : DbContext
    {
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<CompetitionTeam> CompetitionTeams { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        public FootballDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary Keys
            modelBuilder.Entity<Player>().HasKey(player => player.Id);
            modelBuilder.Entity<Team>().HasKey(team => team.Id);
            modelBuilder.Entity<Competition>().HasKey(competition => competition.Id);
            modelBuilder.Entity<CompetitionTeam>().HasKey(competitionTeam => new { competitionTeam.CompetitionId, competitionTeam.TeamId });

            // Foreign keys
            modelBuilder.Entity<Player>().HasOne<Team>().WithMany(team => team.Players);
            modelBuilder.Entity<CompetitionTeam>().HasOne<Competition>().WithMany(competition => competition.CompetitionTeams);
            modelBuilder.Entity<CompetitionTeam>().HasOne<Team>().WithMany(team => team.CompetitionTeams);
        }
    }
}
