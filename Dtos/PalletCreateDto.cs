using System.ComponentModel.DataAnnotations;

namespace Eis.Pallet.Api.Dtos
{
    public class PalletCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Size { get; set; }
    }
}