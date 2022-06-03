using Models.Dbo.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Dbo
{
    public class Event : Location
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

        public override bool Equals(object obj)
        {
            if (obj is null || obj is not Event)
                return false;

            Event? e = obj as Event;
            if (e == null) return false;
            return e.Id == this.Id;
        }

        public bool NeedsUpdate(Event e)
        {
            return !(e.Id == Id && e.Name == Name && e.ShortName == ShortName && 
                e.StartDate == StartDate && e.EndDate == EndDate && e.Year == Year &&
                e.EventType == EventType && e.Week == Week &&
                e.City == City && e.StateProv == StateProv && e.Country == Country &&
                e.Address == Address && e.PostalCode == PostalCode &&
                e.LocationName == LocationName && e.Website == Website);
        }
    }
}
