using System;

namespace Football.Api.ServiceClient.Dtos
{
    public class CompetitionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int NumberOfAvailableSeasons { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
