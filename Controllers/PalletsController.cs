using System;
using System.Collections.Generic;
using AutoMapper;
using Eis.Pallet.Api.Data;
using Eis.Pallet.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Eis.Pallet.Api
{
    [Route("api/proxy/appuser/{appUserId}/[controller]")]
    [ApiController]
    public class PalletsController : ControllerBase
    {
        private readonly IPalletRepo _identityRepo;
        private readonly IMapper _mapper;

        public PalletsController(IPalletRepo identityRepo, IMapper mapper)
        {
            _identityRepo = identityRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PalletReadDto>> GetPalletsForAppUser(int appUserId)
        {
            Console.WriteLine($"--> Get the platforms for user {appUserId}.");
            if(!_identityRepo.AppUserExists(appUserId)) 
            {
                return NotFound();
            }
            
            var result = _identityRepo.GetPalletsForAppUserId(appUserId);
            return Ok(_mapper.Map<IEnumerable<PalletReadDto>>(result));
        }

        [HttpGet("{palletId}", Name="GetPalletForAppUserId")]
        public ActionResult<PalletReadDto> GetPalletForAppUserId(int appUserId, int palletId)
        {
            Console.WriteLine($"--> Get the platforms for user {appUserId} and pallet {palletId}.");
            if(!_identityRepo.AppUserExists(appUserId)) 
            {
                return NotFound();
            }

            var pallet = _identityRepo.GetPallet(appUserId, palletId);

            if(pallet == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PalletReadDto>(pallet));
        }

        [HttpPost]
        public ActionResult<PalletReadDto> CreatePalletForAppUser(int appUserId, PalletCreateDto palletDto) 
        {
            Console.WriteLine($"--> Hit CreatePalletForAppUser: {appUserId}.");
            if(!_identityRepo.AppUserExists(appUserId)) 
            {
                return NotFound();
            }

            var pallet = _mapper.Map<Models.Pallet>(palletDto);
            _identityRepo.CreatePallet(appUserId, pallet);
            _identityRepo.SaveChanges();

            var resultDto = _mapper.Map<PalletReadDto>(pallet);

            return CreatedAtRoute(nameof(GetPalletForAppUserId),
                new {appUserId = appUserId, palletId = resultDto.Id}, resultDto);
        }
    }
}