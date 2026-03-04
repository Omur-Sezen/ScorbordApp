namespace ScorbordApp.Entities;

public class League
{
    public int Id { get; set; }
    public string? Name { get; set; } // Soru işareti ekledik
    public string? Country { get; set; }
    public List<Team> Teams { get; set; } = new(); // Listeyi boş olarak başlattık
}