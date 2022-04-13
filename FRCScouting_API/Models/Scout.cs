using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FRCScouting_API.Models
{
    public class Scout : ScoutBase
    {
        [Key]
        [Column("_id")]
        public int Id { get; set; }

        [Required]
        [Column("template_id")]
        public int TemplateId { get; set; }

        [Required]
        [Column("_template_version")]
        public int TemplateVersion { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("match_key")]
        public string? MatchKey { get; set; }

        [Required]
        [Column("xml")]
        public byte[]? XML { get; set; }
    }
}
