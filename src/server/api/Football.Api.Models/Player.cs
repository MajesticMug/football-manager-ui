using System;

namespace Football.Api.Model
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CountryOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Role { get; set; }

        public Team Team { get; set; }
    }
}
