namespace TestWebAPI.Services
{
    public interface IExternalService
    {
        Task<HttpResponseMessage> GetAsync(string url);
    }
}
