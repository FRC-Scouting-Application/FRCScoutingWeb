using Models.Dbo.Bases;
using Models.Dbo.Interfaces;
using Models.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Dbo
{
    public class Note : ScoutBase, INeedsUpdate<Note>
    {
        [Required]
        public string? Text { get; set; }

        public bool NeedsUpdate(Note obj)
        {
            return NeedsUpdateHelper.NeedsUpdate(this, obj);
        }
    }
}
