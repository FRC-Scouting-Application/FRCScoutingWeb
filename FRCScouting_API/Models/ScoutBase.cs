using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FRCScouting_API.Models
{
    public class ScoutBase
    {
        [Key]
        [Column("_id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("team_key")]
        public string? TeamKey { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("event_key")]
        public string? EventKey { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("scout_name")]
        public string? ScoutName { get; set; }
    }
}
