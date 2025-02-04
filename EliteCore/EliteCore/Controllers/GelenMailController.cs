using EliteCore.Models;
using EliteCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EliteCore.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GelenMailController : ControllerBase
    {
        private readonly GelenMailService gelenMailService;
        public GelenMailController(GelenMailService gelenMailService)
        {
                this.gelenMailService=gelenMailService;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<bool>> EkleAsync(GelenMail gelenMail)
        {
            bool islemSonuc = await gelenMailService.EkleAsync(gelenMail);
            if (islemSonuc)
            {
                return Ok(true); // Başarıyla tamamlandığında true dönüyoruz
            }
            else
            {
                return StatusCode(500, false); // Hata durumunda false dönüyoruz
            }
        }

    }
}
