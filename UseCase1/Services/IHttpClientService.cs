namespace UseCase1.Services
{
    public interface IHttpClientService
    {
        Task<TResponse?> SendGetAsync<TResponse>(string url);
    }
}
