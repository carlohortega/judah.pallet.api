using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eis.Pallet.Api.Models
{
    public class AppUser
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int ExtId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ObjectId { get; set; }

        // Navigation properties
        public ICollection<Pallet> Pallets { get; set; } = new List<Pallet>();
    }
}