using Models.Dbo.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Dbo
{
    public class Scout : ScoutBase
    {
        [Required]
        public int TemplateId { get; set; }

        [Required]
        public int TemplateVersion { get; set; }

        [Required]
        [MaxLength(50)]
        public string? MatchKey { get; set; }

        [Required]
        public byte[]? XML { get; set; }

        public bool NeedsUpdate(Scout scout)
        {
            return !(scout.Id == Id && scout.TeamKey == TeamKey &&
                scout.EventKey == EventKey && scout.ScoutName == ScoutName &&
                scout.TemplateId == TemplateId && scout.TemplateVersion == TemplateVersion &&
                scout.MatchKey == MatchKey && scout.XML == XML);
        }
    }
}
