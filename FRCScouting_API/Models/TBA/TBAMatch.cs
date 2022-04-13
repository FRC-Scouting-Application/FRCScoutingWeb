namespace FRCScouting_API.Models.TBA
{
    public class TBAMatch
    {
        public string? Key { get; set; }
        public int? Match_Number { get; set; }
        public string? Event_Key { get; internal set; }
        public TBAMatchAlliances? Alliances { get; set; }
        public string? Winning_Alliance { get; set; }
        public ulong? Time { get; set; }
        public ulong? Actual_Time { get; set; }
        public ulong? Predicted_Time { get; set; }
        

        public class TBAMatchAlliances
        {
            public TBAMatchAlliance? Red { get; set; }
            public TBAMatchAlliance? Blue { get; set; }
        }

        public class TBAMatchAlliance
        {
            public int Score { get; set; }
            public string[]? Team_Keys { get; set; }
        }
    }
}
