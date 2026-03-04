using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScorbordApp.Entities;

namespace ScorbordApp.Controllers
{
    // Lig Yönetimi: Lig ekleme ve listeleme işlemleri
    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LeaguesController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<League>>> GetLeagues() => await _context.Leagues.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<League>> PostLeague(League league)
        {
            _context.Leagues.Add(league);
            await _context.SaveChangesAsync();
            return Ok(league);
        }
    }

    // Takım Yönetimi: Takım ekleme, listeleme ve silme işlemleri
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TeamsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams() => await _context.Teams.Include(t => t.League).ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return Ok(team);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null) return NotFound();
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

    // Maç Yönetimi ve Puan Durumu Mantığı (2. Hafta Akıllı Çıktı)
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MatchesController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Match>>> GetMatches() => await _context.Matches.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Match>> PostMatch(Match match)
        {
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();
            return Ok(match);
        }

        // Puan Durumu: Ligdeki takımları ve maç sayılarını listeler
        [HttpGet("standings/{leagueId}")]
        public async Task<IActionResult> GetStandings(int leagueId)
        {
            var teams = await _context.Teams.Where(t => t.LeagueId == leagueId).ToListAsync();
            var matches = await _context.Matches.ToListAsync();

            var standings = teams.Select(team => new
            {
                TakimAdi = team.Name,
                OynananMac = matches.Count(m => m.HomeTeamId == team.Id || m.AwayTeamId == team.Id),
                Puan = 0 // 3. haftada maç skorlarına göre otomatik hesaplanacak
            }).ToList();

            return Ok(standings);
        }
    }

    // Oyuncu Yönetimi: Oyuncu ekleme ve listeleme işlemleri
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PlayersController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers() => await _context.Players.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return Ok(player);
        }
    }
}