using System;
using System.Collections.Generic;

namespace Football.Api.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string CountryOfBirth { get; set; }
        public string Nationality { get; set; }

        public List<TeamPlayer> TeamPlayers { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Player otherPlayer)
            {
                return Equals(otherPlayer);
            }

            return false;
        }

        protected bool Equals(Player other)
        {
            return Code == other.Code;
        }

        public override int GetHashCode()
        {
            return (Code != null ? Code.GetHashCode() : 0);
        }
    }
}
