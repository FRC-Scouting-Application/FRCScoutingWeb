using Models.Dbo.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Models.Dbo.Bases
{
    public class ScoutBase : DboBase, IKey<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? TeamKey { get; set; }

        [Required]
        [MaxLength(50)]
        public string? EventKey { get; set; }

        [Required]
        [MaxLength(255)]
        public string? ScoutName { get; set; }
    }
}
