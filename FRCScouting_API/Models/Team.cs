using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FRCScouting_API.Models
{
    public class Team : Location
    {
        [Key]
        [Column("_key")]
        public string? Key { get; set; }

        [Required]
        [Column("team_number")]
        public int TeamNumber { get; set; }

        [Column("nickname")]
        public string? Nickname { get; set; }

        [Required]
        [Column("name")]
        public string? Name { get; set; }

        [Column("rookie_year")]
        public int RookieYear { get; set; }

        
        public override bool Equals(object obj)
        {
            if (obj is null || obj is not Team)
                return false;

            Team? team = obj as Team;
            if (team == null) return false;
            return team.Key == this.Key;
        }

        public bool NeedsUpdate(Team team)
        {
            return !(team.Key == Key && team.TeamNumber == TeamNumber && team.Nickname == Nickname && 
                team.Name == Name && team.RookieYear == RookieYear &&
                team.City == City && team.StateProv == StateProv && team.Country == Country &&
                team.Address == Address && team.PostalCode == PostalCode &&
                team.LocationName == LocationName && team.Website == Website);
        }
    }
}
