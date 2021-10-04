using System;
using System.Collections.Generic;
using AutoMapper;
using Eis.Pallet.Api.Data;
using Eis.Pallet.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Eis.Pallet.Api
{
    [Route("api/proxy/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IPalletRepo _palletRepo;
        private readonly IMapper _mapper;

        public AppUserController(IPalletRepo palletRepo, IMapper mapper)
        {
            _palletRepo = palletRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AppUserReadDto>> GetAllUsers()
        {
            Console.WriteLine("--> Getting all users from PalletService.");

            var items =  _palletRepo.GetAllAppUsers();
            return Ok(_mapper.Map<IEnumerable<AppUserReadDto>>(items));
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound post # Pallet Service.");
            return Ok("Inbound test OK from Pallet Controller.");
        }
    }
}