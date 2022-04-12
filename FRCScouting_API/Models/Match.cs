using System.ComponentModel.DataAnnotations;

namespace FRCScouting_API.Models
{
    public class Match
    {
        [Key]
        public string? Key { get; set; }

        [MaxLength(50)]
        public string? Red_1 { get; set; }

        [MaxLength(50)]
        public string? Red_2 { get; set; }

        [MaxLength(50)]
        public string? Red_3 { get; set; }

        [MaxLength(50)]
        public string? Blue_1 { get; set; }

        [MaxLength(50)]
        public string? Blue_2 { get; set; }

        [MaxLength(50)]
        public string? Blue_3 { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Event_Key { get; set; }

        public int Red_Score { get; set; }

        public int Blue_Score { get; set; }

        [MaxLength(10)]
        public string? Winning_Alliance { get; set; }

        public DateTime Time { get; set; }

        public DateTime Actual_Time { get; set; }

        public DateTime Predicted_Time { get; set; }
    }
}
