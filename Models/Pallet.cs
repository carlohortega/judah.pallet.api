using System.ComponentModel.DataAnnotations;

namespace Eis.Pallet.Api.Models
{
    public class Pallet
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        // Navigation properties
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}