namespace Domain.Interfaces.Services
{
    public interface IRestClientService
    {
        Task<T> GetAsync<T>(string url, Dictionary<string, string>? headers = null);
        Task<T> PostAsync<T>(string url, string body, Dictionary<string, string>? headers = null);
        Task<T> PutAsync<T>(string url, string body, Dictionary<string, string>? headers = null);
        Task<T> DeleteAsync<T>(string url, Dictionary<string, string>? headers = null);
    }
}
