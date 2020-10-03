using System;

namespace Football.Api.Model
{
    public class League
    {
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public string LeagueCode { get; set; }
        public int NumberOfAvailableSeasons { get; set; }
        public DateTime? LastUpdated { get; set; }

        public Team[] Teams { get; set; }
    }
}
