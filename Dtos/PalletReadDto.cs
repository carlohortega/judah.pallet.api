namespace Eis.Pallet.Api.Dtos
{
    public class PalletReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Size { get; set; }
        public int AppUserId { get; set; }
    }
}