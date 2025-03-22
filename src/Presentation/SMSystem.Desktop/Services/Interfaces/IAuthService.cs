namespace SMSystem.Desktop.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(string email, string password);
        Task<bool> RegisterAsync(string email, string fullName, string password, string confirmPassword);
        Task<bool> RefreshTokenAsync();
        bool IsAuthenticated();
        string? GetToken();
        string? GetUserName();
        void Logout();
    }
}