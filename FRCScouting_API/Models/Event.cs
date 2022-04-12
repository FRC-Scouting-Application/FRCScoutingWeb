using System.ComponentModel.DataAnnotations;

namespace FRCScouting_API.Models
{
    public class Event : Location
    {
        [Key]
        public string? Key { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }

        [MaxLength(255)]
        public string? Short_Name { get; set; }

        [Required]
        public DateTime Start_Date { get; set; }

        [Required]
        public DateTime End_Date { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Event_Type { get; set; }

        public int Week { get; set; }
    }
}
