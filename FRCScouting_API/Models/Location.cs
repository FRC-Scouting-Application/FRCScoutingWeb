using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FRCScouting_API.Models
{
    public class Location
    {
        [MaxLength(255)]
        [Column("city")]
        public string? City { get; set; }

        [MaxLength(255)]
        [Column("state_prov")]
        public string? StateProv { get; set; }

        [MaxLength(255)]
        [Column("country")]
        public string? Country { get; set; }

        [Column("address")]
        public string? Address { get; set; }

        [MaxLength(50)]
        [Column("postal_code")]
        public string? PostalCode { get; set; }

        [Column("location_name")]
        public string? LocationName { get; set; }

        [Column("website")]
        public string? Website { get; set; }

    }
}
