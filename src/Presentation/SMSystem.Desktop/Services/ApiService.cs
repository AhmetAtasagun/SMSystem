using SMSystem.Desktop.Models;
using SMSystem.Desktop.Services.Interfaces;
using SMSystem.Domain.Models.AuthModels;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace SMSystem.Desktop.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(Api.BaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<T?> GetAsync<T>(string endpoint, string? token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                var response = await _httpClient.GetAsync(ApiPrefix(endpoint));

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    var responseContent = JsonSerializer.Deserialize<T>(errorContent, _jsonSerializerOptions);

                    if (responseContent is AuthResponse authResponse && !authResponse.IsSuccess)
                        MessageBoxShow.Error(authResponse.Message);
                    else
                        MessageBoxShow.Error($"API Error: {response.StatusCode} - {errorContent}");
                    return default;
                }

                return await response.Content.ReadFromJsonAsync<T>(_jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                MessageBoxShow.Error($"API Error: {ex.Message}");
                return default;
            }
        }

        public async Task<T?> PostAsync<T>(string endpoint, object data, string? token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                var response = await _httpClient.PostAsJsonAsync(ApiPrefix(endpoint), data);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    if (errorContent.Contains("validation errors"))
                    {
                        var errorMessage = GetValidationErrorMessages(errorContent);
                        MessageBoxShow.Error(errorMessage);
                        return default;
                    }
                    var responseContent = JsonSerializer.Deserialize<T>(errorContent, _jsonSerializerOptions);

                    if (responseContent is AuthResponse authResponse && !authResponse.IsSuccess)
                        MessageBoxShow.Error($"{authResponse.Message}");
                    else
                        MessageBoxShow.Error($"API Error: {response.StatusCode} - {errorContent}");

                    return default;
                }

                return await response.Content.ReadFromJsonAsync<T>(_jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                MessageBoxShow.Error($"API Error: {ex.Message}");
                return default;
            }
        }

        public async Task<T?> PutAsync<T>(string endpoint, object data, string? token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                var response = await _httpClient.PutAsJsonAsync(ApiPrefix(endpoint), data);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();

                    var responseContent = JsonSerializer.Deserialize<T>(errorContent, _jsonSerializerOptions);
                    if (responseContent is AuthResponse authResponse && !authResponse.IsSuccess)
                        MessageBoxShow.Error($"{authResponse.Message}");
                    else
                        MessageBoxShow.Error($"API Error: {response.StatusCode} - {errorContent}");
                    return default;
                }

                return await response.Content.ReadFromJsonAsync<T>(_jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                MessageBoxShow.Error($"API Error: {ex.Message}");
                return default;
            }
        }

        public async Task<T?> DeleteAsync<T>(string endpoint, string? token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                var response = await _httpClient.DeleteAsync(ApiPrefix(endpoint));

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();

                    var responseContent = JsonSerializer.Deserialize<T>(errorContent, _jsonSerializerOptions);
                    if (responseContent is AuthResponse authResponse && !authResponse.IsSuccess)
                        MessageBoxShow.Error($"{authResponse.Message}");
                    else
                        MessageBoxShow.Error($"API Error: {response.StatusCode} - {errorContent}");
                    return default;
                }

                return await response.Content.ReadFromJsonAsync<T>(_jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                MessageBoxShow.Error($"API Error: {ex.Message}");
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

        private string GetValidationErrorMessages(string errorContent)
        {
            var responseErrorContent = JsonSerializer.Deserialize<ErrorResponse>(errorContent, _jsonSerializerOptions);
            var errorMessage = $"{responseErrorContent.Title}\n";

            if (responseErrorContent.Errors != null)
            {
                foreach (var error in responseErrorContent.Errors)
                {
                    errorMessage += $"- {error.Key}: {string.Join(", ", error.Value)}\n";
                }
            }
            return errorMessage;
        }

        private string ApiPrefix(string apiEndpoint) => $"api/{apiEndpoint}";

        public async Task<T?> PostFormDataAsync<T>(string endpoint, Dictionary<string, string> formData, string filePath, string fileParameterName, string? token = null)
        {
            try
            {
                SetAuthorizationHeader(token);

                using var content = new MultipartFormDataContent();

                foreach (var item in formData)
                {
                    content.Add(new StringContent(item.Value), item.Key);
                }

                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    var fileContent = new StreamContent(File.OpenRead(filePath));
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue(GetMimeType(filePath));
                    content.Add(fileContent, fileParameterName, Path.GetFileName(filePath));
                }

                var response = await _httpClient.PostAsync(ApiPrefix(endpoint), content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    if (errorContent.Contains("validation errors"))
                    {
                        var errorMessage = GetValidationErrorMessages(errorContent);
                        MessageBoxShow.Error(errorMessage);
                        return default;
                    }

                    try
                    {
                        var responseContent = JsonSerializer.Deserialize<T>(errorContent, _jsonSerializerOptions);
                        if (responseContent is AuthResponse authResponse && !authResponse.IsSuccess)
                            MessageBoxShow.Error($"{authResponse.Message}");
                        else
                            MessageBoxShow.Error($"API Error: {response.StatusCode} - {errorContent}");
                    }
                    catch
                    {
                        MessageBoxShow.Error($"API Error: {response.StatusCode} - {errorContent}");
                    }

                    return default;
                }

                return await response.Content.ReadFromJsonAsync<T>(_jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                MessageBoxShow.Error($"API Error: {ex.Message}");
                return default;
            }
        }

        public async Task<T?> PutFormDataAsync<T>(string endpoint, Dictionary<string, string> formData, string filePath, string fileParameterName, string? token = null)
        {
            try
            {
                SetAuthorizationHeader(token);

                using var content = new MultipartFormDataContent();

                foreach (var item in formData)
                {
                    content.Add(new StringContent(item.Value), item.Key);
                }

                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    var fileContent = new StreamContent(File.OpenRead(filePath));
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue(GetMimeType(filePath));
                    content.Add(fileContent, fileParameterName, Path.GetFileName(filePath));
                }

                var response = await _httpClient.PutAsync(ApiPrefix(endpoint), content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    if (errorContent.Contains("validation errors"))
                    {
                        var errorMessage = GetValidationErrorMessages(errorContent);
                        MessageBoxShow.Error(errorMessage);
                        return default;
                    }

                    try
                    {
                        var responseContent = JsonSerializer.Deserialize<T>(errorContent, _jsonSerializerOptions);
                        if (responseContent is AuthResponse authResponse && !authResponse.IsSuccess)
                            MessageBoxShow.Error($"{authResponse.Message}");
                        else
                            MessageBoxShow.Error($"API Error: {response.StatusCode} - {errorContent}");
                    }
                    catch
                    {
                        MessageBoxShow.Error($"API Error: {response.StatusCode} - {errorContent}");
                    }

                    return default;
                }

                return await response.Content.ReadFromJsonAsync<T>(_jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                MessageBoxShow.Error($"API Error: {ex.Message}");
                return default;
            }
        }

        private string GetMimeType(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLowerInvariant();
            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".bmp" => "image/bmp",
                ".pdf" => "application/pdf",
                _ => "application/octet-stream"
            };
        }
    }
}