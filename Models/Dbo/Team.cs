using Models.Dbo.Bases;
using Models.Dbo.Interfaces;
using Models.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Dbo
{
    public class Team : DboBase, ILocation, INeedsUpdate<Team>
    {
        [Key]
        public string? Id { get; set; }

        [Required]
        public int TeamNumber { get; set; }

        public string? Nickname { get; set; }

        [Required]
        public string? Name { get; set; }

        public int RookieYear { get; set; }

        #region Location
        public string? City { get; set; }
        public string? StateProv { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public string? LocationName { get; set; }
        public string? Website { get; set; }
        #endregion Location

        public bool NeedsUpdate(Team obj)
        {
            return NeedsUpdateHelper.NeedsUpdate(this, obj);
        }
    }
}
