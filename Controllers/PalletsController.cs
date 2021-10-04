using System;
using AutoMapper;
using Eis.Pallet.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Eis.Pallet.Api
{
    [Route("api/proxy/[controller]")]
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
    }
}