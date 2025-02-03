using EliteCore.Models;
using EliteCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EliteCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GelenMailController : ControllerBase
    {
        private readonly GelenMailService gelenMailService;
        public GelenMailController(GelenMailService gelenMailService)
        {
                this.gelenMailService=gelenMailService;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GelenMail), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(GelenMail), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GelenMail>> EkleAsync(GelenMail gelenMail)
        {
            
            GelenMail islemSonuc = await gelenMailService.EkleAsync(gelenMail);
            return islemSonuc;
        }
    }
}
