using System.ComponentModel.DataAnnotations;

namespace FRCScouting_API.Models
{
    public class ScoutBase
    {
        [Required]
        [MaxLength(50)]
        public string? Team_Key { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Event_Key { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Scout_Name { get; set; }
    }
}
