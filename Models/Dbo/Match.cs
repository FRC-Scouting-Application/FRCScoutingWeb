using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Dbo
{
    public class Match
    {
        [Key]
        public string? Id { get; set; }

        [Required]
        public int MatchNumber { get; set; }

        [MaxLength(50)]
        public string? Red1 { get; set; }

        [MaxLength(50)]
        public string? Red2 { get; set; }

        [MaxLength(50)]
        public string? Red3 { get; set; }

        [MaxLength(50)]
        public string? Blue1 { get; set; }

        [MaxLength(50)]
        public string? Blue2 { get; set; }

        [MaxLength(50)]
        public string? Blue3 { get; set; }

        [Required]
        [MaxLength(50)]
        public string? EventKey { get; set; }

        public int RedScore { get; set; }

        public int BlueScore { get; set; }

        [MaxLength(10)]
        public string? WinningAlliance { get; set; }

        public DateTime Time { get; set; }

        public DateTime ActualTime { get; set; }

        public DateTime PredictedTime { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null || obj is not Match)
                return false;

            Match? match = obj as Match;
            if (match == null) return false;
            return match.Id == Id;
        }

        public bool NeedsUpdate(Match match)
        {
            return !(match.Id == Id && match.MatchNumber == MatchNumber &&
                match.Red1 == Red1 && match.Red2 == Red2 && match.Red3 == Red3 &&
                match.Blue1 == Blue1 && match.Blue2 == Blue2 && match.Blue3 == Blue3 &&
                match.EventKey == EventKey && match.RedScore == RedScore &&
                match.BlueScore == BlueScore && match.WinningAlliance == WinningAlliance &&
                match.Time == Time && match.ActualTime == ActualTime &&
                match.PredictedTime == PredictedTime);
        }
    }
}
