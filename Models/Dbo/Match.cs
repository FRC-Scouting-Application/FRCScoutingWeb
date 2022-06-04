using Models.Dbo.Bases;
using Models.Dbo.Interfaces;
using Models.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Models.Dbo
{
    public class Match : DboBase, INeedsUpdate<Match>
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

        public bool NeedsUpdate(Match obj)
        {
            return NeedsUpdateHelper.NeedsUpdate(this, obj);
        }
    }
}
