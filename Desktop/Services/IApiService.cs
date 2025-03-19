using System.Net.Http.Headers;

namespace SMSystem.Desktop.Services
{
    public interface IApiService
    {
        Task<T?> GetAsync<T>(string endpoint, string? token = null);
        Task<T?> PostAsync<T>(string endpoint, object data, string? token = null);
        Task<T?> PutAsync<T>(string endpoint, object data, string? token = null);
        Task<T?> DeleteAsync<T>(string endpoint, string? token = null);
    }

    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:5000/api";

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T?> GetAsync<T>(string endpoint, string? token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                var response = await _httpClient.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"API Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<T?> PostAsync<T>(string endpoint, object data, string? token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                var response = await _httpClient.PostAsJsonAsync(endpoint, data);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"API Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<T?> PutAsync<T>(string endpoint, object data, string? token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                var response = await _httpClient.PutAsJsonAsync(endpoint, data);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"API Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public async Task<T?> DeleteAsync<T>(string endpoint, string? token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                var response = await _httpClient.DeleteAsync(endpoint);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"API Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        private void SetAuthorizationHeader(string? token)
        {
            if (string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = null;
                return;
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}