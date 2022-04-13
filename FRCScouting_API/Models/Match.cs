using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FRCScouting_API.Models
{
    public class Match
    {
        [Key]
        [Column("_key")]
        public string? Key { get; set; }

        [Required]
        [Column("match_number")]
        public int MatchNumber { get; set; }

        [MaxLength(50)]
        [Column("red_1")]
        public string? Red1 { get; set; }

        [MaxLength(50)]
        [Column("red_2")]
        public string? Red2 { get; set; }

        [MaxLength(50)]
        [Column("red_3")]
        public string? Red3 { get; set; }

        [MaxLength(50)]
        [Column("blue_1")]
        public string? Blue1 { get; set; }

        [MaxLength(50)]
        [Column("blue_2")]
        public string? Blue2 { get; set; }

        [MaxLength(50)]
        [Column("blue_3")]
        public string? Blue3 { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("event_key")]
        public string? EventKey { get; set; }

        [Column("red_score")]
        public int RedScore { get; set; }

        [Column("blue_score")]
        public int BlueScore { get; set; }

        [MaxLength(10)]
        [Column("winning_alliance")]
        public string? WinningAlliance { get; set; }

        [Column("time")]
        public DateTime Time { get; set; }

        [Column("actual_time")]
        public DateTime ActualTime { get; set; }

        [Column("predicted_time")]
        public DateTime PredictedTime { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null || obj is not Match)
                return false;

            Match? match = obj as Match;
            if (match == null) return false;
            return match.Key == this.Key;
        }

        public bool NeedsUpdate(Match match)
        {
            return !(match.Key == Key && match.MatchNumber == MatchNumber &&
                match.Red1 == Red1 && match.Red2 == Red2 && match.Red3 == Red3 &&
                match.Blue1 == Blue1 && match.Blue2 == Blue2 && match.Blue3 == Blue3 &&
                match.EventKey == EventKey && match.RedScore == RedScore &&
                match.BlueScore == BlueScore && match.WinningAlliance == WinningAlliance &&
                match.Time == Time && match.ActualTime == ActualTime && 
                match.PredictedTime == PredictedTime);
        }
    }
}
