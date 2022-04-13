using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FRCScouting_API.Models
{
    public class Event : Location
    {
        [Key]
        [Column("_key")]
        public string? Key { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("name")]
        public string? Name { get; set; }

        [MaxLength(255)]
        [Column("short_name")]
        public string? ShortName { get; set; }

        [Required]
        [Column("start_date")]
        public DateTime? StartDate { get; set; }

        [Required]
        [Column("end_date")]
        public DateTime? EndDate { get; set; }

        [Required]
        [Column("year")]
        public int Year { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("event_type")]
        public string? EventType { get; set; }

        [Column("week")]
        public int Week { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null || obj is not Event)
                return false;

            Event? e = obj as Event;
            if (e == null) return false;
            return e.Key == this.Key;
        }

        public bool NeedsUpdate(Event e)
        {
            return !(e.Key == Key && e.Name == Name && e.ShortName == ShortName && 
                e.StartDate == StartDate && e.EndDate == EndDate && e.Year == Year &&
                e.EventType == EventType && e.Week == Week &&
                e.City == City && e.StateProv == StateProv && e.Country == Country &&
                e.Address == Address && e.PostalCode == PostalCode &&
                e.LocationName == LocationName && e.Website == Website);
        }
    }
}
