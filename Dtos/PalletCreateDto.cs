using System.ComponentModel.DataAnnotations;

namespace Eis.Pallet.Api.Dtos
{
    public class PalletCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}