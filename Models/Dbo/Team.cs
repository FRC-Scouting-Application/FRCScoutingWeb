using Models.Dbo.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Dbo
{
    public class Team : Location
    {
        [Key]
        public string? Id { get; set; }

        [Required]
        public int TeamNumber { get; set; }

        public string? Nickname { get; set; }

        [Required]
        public string? Name { get; set; }

        public int RookieYear { get; set; }


        public override bool Equals(object obj)
        {
            if (obj is null || obj is not Team)
                return false;

            Team? team = obj as Team;
            if (team == null) return false;
            return team.Id == Id;
        }

        public bool NeedsUpdate(Team team)
        {
            return !(team.Id == Id && team.TeamNumber == TeamNumber && team.Nickname == Nickname &&
                team.Name == Name && team.RookieYear == RookieYear &&
                team.City == City && team.StateProv == StateProv && team.Country == Country &&
                team.Address == Address && team.PostalCode == PostalCode &&
                team.LocationName == LocationName && team.Website == Website);
        }
    }
}
