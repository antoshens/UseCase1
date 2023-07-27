using Microsoft.AspNetCore.Mvc;
using UseCase1.Models;
using UseCase1.Services;

namespace UseCase1.Controllers
{
    public class HomeController : Controller
    {
        private const int POPULATION_MULTIPLIER = 1000000;

        private readonly IHttpClientService _httpClient;

        public HomeController(IHttpClientService httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        [Route("api/countries")]
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

        private IEnumerable<Country> FilterByName(IEnumerable<Country> countries, string filterStr)
        {
            if (string.IsNullOrWhiteSpace(filterStr))
            {
                return countries;
            }

            if (countries is null)
            {
                return null;
            }

            return countries.Where(c => c.Name.Common.Contains(filterStr));
        }

        private IEnumerable<Country> FilterByPopulation(IEnumerable<Country> countries, int maxPopulation)
        {
            if (maxPopulation <= 0)
            {
                return countries;
            }

            if (countries is null)
            {
                return null;
            }

            return countries.Where(c => c.Population < maxPopulation * POPULATION_MULTIPLIER);
        }

        private IEnumerable<Country> SortCountries(IEnumerable<Country> countries, string sortOrder)
        {
            if (string.IsNullOrWhiteSpace(sortOrder))
            {
                return countries;
            }

            if (countries is null)
            {
                return null;
            }

            if (sortOrder.Equals("ascend", StringComparison.OrdinalIgnoreCase) || sortOrder.Equals("asc", StringComparison.OrdinalIgnoreCase))
            {
                return countries.OrderBy(c => c.Name.Common).AsEnumerable();
            }
            else if (sortOrder.Equals("descend", StringComparison.OrdinalIgnoreCase) || sortOrder.Equals("desc", StringComparison.OrdinalIgnoreCase))
            {
                return countries.OrderByDescending(c => c.Name.Common).AsEnumerable();
            }

            return countries;
        }
    }
}
