using Newtonsoft.Json;

namespace UseCase1.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public HttpClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

            _httpClient = _httpClientFactory.CreateClient("usecase1");
        }

        public async Task<TResponse?> SendGetAsync<TResponse>(string url)
        {
            var response = await _httpClient.GetAsync(url);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var responseModel = JsonConvert.DeserializeObject<TResponse>(jsonResponse);

                return responseModel;
            }

            return default(TResponse);
        }
    }
}
