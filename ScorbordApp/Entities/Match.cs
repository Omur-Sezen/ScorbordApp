namespace ScorbordApp.Entities;

public class Match
{
    public int Id { get; set; } // Bunu eklediğinden emin ol
    public int HomeTeamId { get; set; }
    public int AwayTeamId { get; set; }
    public DateTime MatchDate { get; set; }
    // ... diğer alanlar
}