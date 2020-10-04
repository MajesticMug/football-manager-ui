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
            // Table Names
            modelBuilder.Entity<Competition>().ToTable("Competition");
            modelBuilder.Entity<CompetitionTeam>().ToTable("CompetitionTeam");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Player>().ToTable("Player");

            // Primary Keys
            modelBuilder.Entity<Player>().HasKey(player => player.Id);
            modelBuilder.Entity<Team>().HasKey(team => team.Id);
            modelBuilder.Entity<Competition>().HasKey(competition => competition.Id);
            modelBuilder.Entity<CompetitionTeam>().HasKey(competitionTeam => new {competitionTeam.TeamId, competitionTeam.CompetitionId});

            // Indexes
            modelBuilder.Entity<Competition>().HasIndex(competition => competition.Code).IsUnique();
            modelBuilder.Entity<Team>().HasIndex(team => team.Code).IsUnique();
            modelBuilder.Entity<Player>().HasIndex(player => player.Code).IsUnique();

            // Foreign keys
            modelBuilder
                .Entity<CompetitionTeam>()
                .HasOne(ct => ct.Competition)
                .WithMany(c => c.CompetitionTeams)
                .HasForeignKey(ct => ct.CompetitionId);

            modelBuilder
                .Entity<CompetitionTeam>()
                .HasOne(ct => ct.Team)
                .WithMany(t => t.CompetitionTeams)
                .HasForeignKey(ct => ct.TeamId);

            modelBuilder
                .Entity<Player>()
                .HasOne<Team>()
                .WithMany(team => team.Players)
                .HasForeignKey(player => player.TeamId);

            // Misc
            modelBuilder
                .Entity<Player>()
                .Ignore(player => player.TeamCode);


            base.OnModelCreating(modelBuilder);
        }
    }
}
