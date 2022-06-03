using Models.Dbo.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Dbo
{
    public class Note : ScoutBase
    {
        [Required]
        public string? Text { get; set; }

        public bool NeedsUpdate(Note note)
        {
            return !(note.Id == Id && note.TeamKey == TeamKey &&
                note.EventKey == EventKey && note.ScoutName == ScoutName);
        }
    }
}
