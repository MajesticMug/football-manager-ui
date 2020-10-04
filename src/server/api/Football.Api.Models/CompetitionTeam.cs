namespace Football.Api.Models
{
    public class CompetitionTeam
    {
        public int CompetitionId { get; set; }
        public int TeamId { get; set; }

        public Competition Competition { get; set; }
        public Team Team { get; set; }
    }
}
