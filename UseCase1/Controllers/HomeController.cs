using Microsoft.AspNetCore.Mvc;
using UseCase1.Models.UseCase1.Models;
using UseCase1.Services;

namespace UseCase1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientService _httpClient;

        public HomeController(IHttpClientService httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        [Route("api/countries/{name?}/{limit?}/{population?}")]
        public async Task<IActionResult> GetCountries(string name, int limit, string population)
        {
            try
            {
                var countries = await _httpClient.SendGetAsync<List<Country>>("v3.1/all");

                return Ok(countries);
            }
            catch(Exception ex)
            {

#if DEBUG
                return BadRequest(ex.Message);
#else
                return BadRequest("Unable to load countries.");
#endif
            }
        }
    }
}
