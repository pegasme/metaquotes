using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetaQuotes.IPSearch.Web.Controllers
{
    [ApiController]
    public class SearchController : ControllerBase
    {
        [HttpGet]
        [Route("/ip/location")]
        public async Task<IActionResult> ByIp(string ip) {
            if (string.IsNullOrWhiteSpace(ip))
                throw new Exception("ip is empty");

            return Ok();
        }

        [HttpGet]
        [Route("/city/locations")]
        public async Task<IActionResult> ByCity(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
                throw new Exception("City is empty");

            return Ok();
        }
    }
}
