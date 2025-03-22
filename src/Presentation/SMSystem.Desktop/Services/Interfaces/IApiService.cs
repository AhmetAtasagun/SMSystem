namespace SMSystem.Desktop.Services.Interfaces
{
    public interface IApiService
    {
        Task<T?> GetAsync<T>(string endpoint, string? token = null);
        Task<T?> PostAsync<T>(string endpoint, object data, string? token = null);
        Task<T?> PutAsync<T>(string endpoint, object data, string? token = null);
        Task<T?> DeleteAsync<T>(string endpoint, string? token = null);
        Task<T?> PostFormDataAsync<T>(string endpoint, Dictionary<string, string> formData, string filePath, string fileParameterName, string? token = null);
        Task<T?> PutFormDataAsync<T>(string endpoint, Dictionary<string, string> formData, string filePath, string fileParameterName, string? token = null);
    }
}