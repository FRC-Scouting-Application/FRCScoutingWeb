using System.ComponentModel.DataAnnotations;

namespace FRCScouting_API.Models
{
    public class Note : ScoutBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Text { get; set; }
    }
}
