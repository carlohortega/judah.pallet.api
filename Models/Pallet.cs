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
        [Required]
        public decimal Size { get; set; }
        [Required]
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}