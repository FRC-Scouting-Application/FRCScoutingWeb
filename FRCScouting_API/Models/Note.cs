using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FRCScouting_API.Models
{
    public class Note : ScoutBase
    {
        [Required]
        [Column("text")]
        public string? Text { get; set; }

        public bool NeedsUpdate(Note note)
        {
            return !(note.Id == Id && note.TeamKey == TeamKey &&
                note.EventKey == EventKey && note.ScoutName == ScoutName);
        }
    }
}
