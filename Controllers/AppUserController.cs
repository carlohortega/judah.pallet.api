using System;
using Microsoft.AspNetCore.Mvc;

namespace Eis.Pallet.Api
{
    [Route("api/proxy/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        public AppUserController()
        {

        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound post # Pallet Service.");
            return Ok("Inbound test OK from Pallet Controller.");
        }
    }
}