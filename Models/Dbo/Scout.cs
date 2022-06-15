using Models.Dbo.Bases;
using Models.Dbo.Interfaces;
using Models.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Models.Dbo
{
    public class Scout : ScoutBase, INeedsUpdate<Scout>
    {
        [Required]
        public int TemplateId { get; set; }

        [Required]
        public int TemplateVersion { get; set; }

        [Required]
        [MaxLength(50)]
        public string? MatchKey { get; set; }

        [Required]
        public string? Data { get; set; }

        public bool NeedsUpdate(Scout obj)
        {
            return NeedsUpdateHelper.NeedsUpdate(this, obj);
        }
    }
}
