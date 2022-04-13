using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FRCScouting_API.Models
{
    public class Note : ScoutBase
    {
        [Key]
        [Column("_id")]
        public int Id { get; set; }

        [Required]
        [Column("text")]
        public string? Text { get; set; }
    }
}
