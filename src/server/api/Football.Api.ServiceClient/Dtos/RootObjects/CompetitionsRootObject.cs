namespace Football.Api.ServiceClient.Dtos.RootObjects
{
    internal class CompetitionsRootObject
    {
        public int Count { get; set; }
        public CompetitionDto[] Competitions { get; set; }
    }
}
