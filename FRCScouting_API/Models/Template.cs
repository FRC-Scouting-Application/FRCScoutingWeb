using System.ComponentModel.DataAnnotations;

namespace FRCScouting_API.Models
{
    public class Template
    {
        [Key]
        public int Id { get; set; }

        public int Version { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Type { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }

        public bool Default_Template { get; set; }

        public DateTime Created { get; set; }

        [Required]
        public byte[]? XML { get; set; }
    }
}
