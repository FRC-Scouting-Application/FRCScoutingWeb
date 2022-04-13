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

        public bool NeedsUpdate(Template template)
        {
            return !(template.Id == Id && template.Version == Version && template.Type == Type && 
                    template.Name == Name && template.DefaultTemplate == DefaultTemplate &&
                    template.Created == Created && template.XML == XML);
        }
    }
}
