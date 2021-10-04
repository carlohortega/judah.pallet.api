using AutoMapper;
using Eis.Pallet.Api.Dtos;
using Eis.Pallet.Api.Models;

namespace Eis.Pallet.Api.Profiles
{
    public class PalletProfile : Profile
    {
        public PalletProfile()
        {
            // Source --> Target
            CreateMap<AppUser, AppUserReadDto>();
            CreateMap<PalletCreateDto, Models.Pallet>();
            CreateMap<Models.Pallet, PalletReadDto>();
        }
    }
}