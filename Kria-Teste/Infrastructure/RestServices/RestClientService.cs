using Domain.Interfaces.Services;
using RestSharp;
using System.Text.Json;

namespace Infrastructure.RestServices
{
    public class RestClientService : IRestClientService
    {
        public async Task<T> DeleteAsync<T>(string url, Dictionary<string, string>? headers = null)
        {
            var client = new RestClient();
            var request = new RestRequest(url, Method.Delete);

            AddHeaders(request, headers);

            return await ExecuteRequestAsync<T>(client, request).ConfigureAwait(false);
        }

        public async Task<T> GetAsync<T>(string url, Dictionary<string, string>? headers = null)
        {
            var client = new RestClient();
            var request = new RestRequest(url, Method.Get);

            AddHeaders(request, headers);

            return await ExecuteRequestAsync<T>(client, request).ConfigureAwait(false);
        }

        public async Task<T> PostAsync<T>(string url, string body, Dictionary<string, string>? headers = null)
        {
            var client = new RestClient();
            var request = new RestRequest(url, Method.Post);

            AddHeaders(request, headers);

            if (!string.IsNullOrEmpty(body))
            {
                request.AddStringBody(body, "application/json");
            }

            return await ExecuteRequestAsync<T>(client, request).ConfigureAwait(false);
        }

        public async Task<T> PutAsync<T>(string url, string body, Dictionary<string, string>? headers = null)
        {
            var client = new RestClient();
            var request = new RestRequest(url, Method.Put);

            AddHeaders(request, headers);

            if (!string.IsNullOrEmpty(body))
            {
                request.AddStringBody(body, "application/json");
            }

            return await ExecuteRequestAsync<T>(client, request).ConfigureAwait(false);
        }

        // --- Helpers ---

        private static void AddHeaders(RestRequest request, Dictionary<string, string>? headers)
        {
            if (headers == null) return;

            foreach (var kv in headers)
            {
                request.AddOrUpdateHeader(kv.Key, kv.Value);
            }
        }

        private static async Task<T> ExecuteRequestAsync<T>(RestClient client, RestRequest request)
        {
            var response = await client.ExecuteAsync(request);

            if (response == null)
                throw new InvalidOperationException("Nenhuma resposta recebida do servidor.");

            if (!response.IsSuccessful)
                throw new HttpRequestException($"Requisição falhou com status {(int)response.StatusCode} - {response.StatusDescription}: {response.Content}");

            var content = response.Content ?? string.Empty;

            if (typeof(T) == typeof(string))
            {
                return (T)(object)content;
            }

            if (string.IsNullOrWhiteSpace(content))
                throw new InvalidOperationException("Resposta vazia; não é possível desserializar para o tipo solicitado.");

            var result = JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result == null ? throw new InvalidOperationException("Falha ao desserializar a resposta para o tipo solicitado.") : result;
        }
    }
}
