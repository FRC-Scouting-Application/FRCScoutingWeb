using Models.Dbo.Bases;
using Models.Dbo.Interfaces;
using Models.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Dbo
{
    public class Template : DboBase, INeedsUpdate<Template>, IKey<int>
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
        public string? Data { get; set; }

        public bool NeedsUpdate(Template obj)
        {
            return NeedsUpdateHelper.NeedsUpdate(this, obj);
        }
    }
}
