using AutoMapper;
using Eis.Identity.Api;
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
            CreateMap<AppUserPublishedDto, AppUser>()
                .ForMember(dest => dest.ExtId, opt => opt.MapFrom(src => src.Id));
            CreateMap<GrpcIdentityModel, AppUser>()
                .ForMember(dest => dest.ExtId, opt => opt.MapFrom(src => src.AppUserId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ObjectId, opt => opt.MapFrom(src => src.ObjectId))
                .ForMember(dest => dest.Pallets, opt => opt.Ignore());
        }
    }
}