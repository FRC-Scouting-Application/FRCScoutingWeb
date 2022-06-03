using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Dbo
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

        public bool DefaultTemplate { get; set; }

        [Required]
        [Column("xml")]
        public byte[]? XML { get; set; }

        public bool NeedsUpdate(Template template)
        {
            return !(template.Id == Id && template.Version == Version && template.Type == Type &&
                    template.Name == Name && template.DefaultTemplate == DefaultTemplate && template.XML == XML);
        }
    }
}
