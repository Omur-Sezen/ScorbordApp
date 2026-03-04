using Microsoft.EntityFrameworkCore;
using ScorbordApp.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Team> Teams { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<League> Leagues { get; set; }
    public DbSet<Match> Matches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 1. Örnek Lig Ekle
        modelBuilder.Entity<League>().HasData(
            new League { Id = 1, Name = "Trendyol Süper Lig", Country = "Türkiye" }
        );

        // 2. Örnek Takım Ekle (Trabzonspor)
        modelBuilder.Entity<Team>().HasData(
            new Team { Id = 1, Name = "Trabzonspor", City = "Trabzon", LeagueId = 1 }
        );

        // 3. Örnek Oyuncu Ekle
        modelBuilder.Entity<Player>().HasData(
            new Player { Id = 1, Name = "Uğurcan Çakır", Position = "Kaleci", Age = 29, TeamId = 1 }
        );
    }
}