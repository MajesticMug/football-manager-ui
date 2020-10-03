namespace Football.Api.ServiceClient.Dtos.RootObjects
{
    internal class TeamsRootObject
    {
        public int Count { get; set; }
        public CompetitionDto Competition { get; set; }
        public TeamDto[] Teams { get; set; }
    }
}
