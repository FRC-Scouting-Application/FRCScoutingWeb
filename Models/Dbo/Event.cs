using Models.Dbo.Bases;
using Models.Dbo.Interfaces;
using Models.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Dbo
{
    public class Event : DboBase, ILocation, INeedsUpdate<Event>, IKey<string>
    {
        [Key]
        public string? Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }

        [MaxLength(255)]
        public string? ShortName { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [MaxLength(50)]
        public string? EventType { get; set; }

        public int Week { get; set; }

        #region Location
        public string? City { get; set; }
        public string? StateProv { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public string? LocationName { get; set; }
        public string? Website { get; set; }
        #endregion Location

        public bool NeedsUpdate(Event obj)
        {
            return NeedsUpdateHelper.NeedsUpdate(this, obj);
        }
    }
}
