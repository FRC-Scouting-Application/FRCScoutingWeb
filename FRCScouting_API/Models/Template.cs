using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FRCScouting_API.Models
{
    public class Template
    {
        [Key]
        [Column("_id")]
        public int Id { get; set; }

        [Column("_version")]
        public int Version { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("type")]
        public string? Type { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("name")]
        public string? Name { get; set; }

        [Column("default_template")]
        public bool DefaultTemplate { get; set; }

        [Column("created")]
        public DateTime Created { get; set; }

        [Required]
        [Column("xml")]
        public byte[]? XML { get; set; }
    }
}
