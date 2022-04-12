using System.ComponentModel.DataAnnotations;

namespace FRCScouting_API.Models
{
    public class Scout : ScoutBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Template_Id { get; set; }

        [Required]
        public int Template_Version { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Match_Key { get; set; }

        [Required]
        public byte[]? XML { get; set; }
    }
}
