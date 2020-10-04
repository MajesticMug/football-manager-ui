using System;
using System.Collections.Generic;

namespace Football.Api.Models
{
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string AreaName { get; set; }

        public List<CompetitionTeam> CompetitionTeams { get; set; }
    }
}
