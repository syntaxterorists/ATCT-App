
using ATCT_Frontend.Models;
using Newtonsoft.Json;
using System.Text.Json;

namespace ATCT_Frontend.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://10.0.2.2:5279")
            };
        }

        public async Task<List<Session>> GetSessionsAsync()
        {
            var response = await _httpClient.GetAsync("http://10.0.2.2:5279/api/Sessions");

            if (!response.IsSuccessStatusCode)
                return new List<Session>();

            var json = await response.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<List<Session>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<string> RegisterToSessionAsync(int sessionId, int userId)
        {
            var response = await _httpClient.PostAsync(
                $"http://10.0.2.2:5279/api/Sessions/{sessionId}/register/{userId}", null);

            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return responseBody;
            else
                return $"Greška pri prijavi: {response.StatusCode} - {responseBody}";
        }

        public async Task<List<Speaker>> GetSpeakersAsync()
        {
            var response = await _httpClient.GetAsync("/api/Speakers");

            if (!response.IsSuccessStatusCode)
                return new List<Speaker>();

            var json = await response.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<List<Speaker>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }


    }
}
