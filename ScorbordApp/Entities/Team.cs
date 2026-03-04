namespace ScorbordApp.Entities;

public class Team
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? City { get; set; }
    public int LeagueId { get; set; }
    public League? League { get; set; } // Soru işareti ekledik
    public List<Player> Players { get; set; } = new(); // Listeyi boş olarak başlattık
}