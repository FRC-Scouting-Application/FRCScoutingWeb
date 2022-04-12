using System.ComponentModel.DataAnnotations;

namespace FRCScouting_API.Models
{
    public class Team : Location
    {
        [Key]
        public string? Key { get; set; }

        [Required]
        public int Team_Number { get; set; }

        public string? Nickname { get; set; }

        [Required]
        public string? Name { get; set; }

        public int Rookie_Year { get; set; }
    }
}
