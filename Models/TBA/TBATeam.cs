namespace Models.TBA
{
    public class TBATeam : TBALocation
    {
        public string? Key { get; set; }
        public int? Team_number { get; set; }
        public string? Nickname { get; set; }
        public string? Name { get; set; }
        public int? Rookie_Year { get; set; }
    }
}
