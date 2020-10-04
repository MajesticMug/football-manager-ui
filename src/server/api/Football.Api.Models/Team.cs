namespace Football.Api.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Tla { get; set; }
        public string Email { get; set; }
        public string AreaName { get; set; }

        public Player[] Players { get; set; }
        public CompetitionTeam[] CompetitionTeams { get; set; }
    }
}
