using System.ComponentModel.DataAnnotations;

namespace Models.Dbo.Interfaces
{
    public interface ILocation
    {
        [MaxLength(255)]
        public string? City { get; set; }

        [MaxLength(255)]
        public string? StateProv { get; set; }

        [MaxLength(255)]
        public string? Country { get; set; }

        public string? Address { get; set; }

        [MaxLength(50)]
        public string? PostalCode { get; set; }

        public string? LocationName { get; set; }

        public string? Website { get; set; }

    }
}
