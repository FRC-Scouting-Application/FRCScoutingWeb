using System.ComponentModel.DataAnnotations;

namespace FRCScouting_API.Models
{
    public class Location
    {
        [MaxLength(255)]
        public string? City { get; set; }

        [MaxLength(255)]
        public string? State_Prov { get; set; }

        [MaxLength(255)]
        public string? Country { get; set; }

        public string? Address { get; set; }

        [MaxLength(50)]
        public string? Postal_Code { get; set; }

        public string? Location_Name { get; set; }

        public string? Website { get; set; }
    }
}
