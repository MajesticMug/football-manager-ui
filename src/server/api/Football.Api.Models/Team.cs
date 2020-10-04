using System.Collections.Generic;

namespace Football.Api.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Tla { get; set; }
        public string Email { get; set; }
        public string AreaName { get; set; }

        public List<CompetitionTeam> CompetitionTeams { get; set; }
        public List<Player> Players { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Team otherTeam)
            {
                return Equals(otherTeam);
            }

            return false;
        }

        protected bool Equals(Team other)
        {
            return Code == other.Code;
        }

        public override int GetHashCode()
        {
            return (Code != null ? Code.GetHashCode() : 0);
        }
    }
}
