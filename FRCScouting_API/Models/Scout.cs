using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FRCScouting_API.Models
{
    public class Scout : ScoutBase
    {
        [Required]
        [Column("template_id")]
        public int TemplateId { get; set; }

        [Required]
        [Column("template_version")]
        public int TemplateVersion { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("match_key")]
        public string? MatchKey { get; set; }

        [Required]
        [Column("xml")]
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
