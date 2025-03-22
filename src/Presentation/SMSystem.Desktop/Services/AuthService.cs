using SMSystem.Desktop.Models;
using SMSystem.Desktop.Services.Interfaces;
using SMSystem.Domain.Models.AuthModels;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace SMSystem.Desktop.Services
{
    public class AuthService : IAuthService
    {
        private readonly IApiService _apiService;
        private string? _token;
        private string? _refreshToken;
        private string? _userName;

        public AuthService(IApiService apiService)
        {
            _apiService = apiService;
            LoadTokenFromStorage();
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var loginModel = new { Email = email, Password = password };
            var response = await _apiService.PostAsync<AuthResponse>("auth/login", loginModel);

            if (response == null) return false;

            var responseStr = JsonSerializer.Serialize(response);
            var authResponse = JsonSerializer.Deserialize<AuthResponse>(responseStr);

            if (authResponse?.IsSuccess == true && !string.IsNullOrEmpty(authResponse.Token))
            {
                _token = authResponse.Token;
                _refreshToken = authResponse.RefreshToken;
                _userName = GetUserNameFromToken(authResponse.Token);
                SaveTokenToStorage();
                return true;
            }
            else
            {
                MessageBoxShow.Error(authResponse.Message);
            }

            return false;
        }

        public async Task<bool> RegisterAsync(string email, string fullName, string password, string confirmPassword)
        {
            var registerModel = new
            {
                Email = email,
                FullName = fullName,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var response = await _apiService.PostAsync<dynamic>("auth/register", registerModel);

            if (response == null) return false;

            var responseStr = JsonSerializer.Serialize(response);
            var authResponse = JsonSerializer.Deserialize<AuthResponse>(responseStr);

            return authResponse?.IsSuccess == true;
        }

        public async Task<bool> RefreshTokenAsync()
        {
            if (string.IsNullOrEmpty(_refreshToken)) return false;

            var refreshModel = new { RefreshToken = _refreshToken };
            var response = await _apiService.PostAsync<dynamic>("auth/refresh-token", refreshModel);

            if (response == null) return false;

            var responseStr = JsonSerializer.Serialize(response);
            var authResponse = JsonSerializer.Deserialize<AuthResponse>(responseStr);

            if (authResponse?.IsSuccess == true && !string.IsNullOrEmpty(authResponse.Token))
            {
                _token = authResponse.Token;
                _refreshToken = authResponse.RefreshToken;
                _userName = GetUserNameFromToken(authResponse.Token);
                SaveTokenToStorage();
                return true;
            }

            return false;
        }

        public bool IsAuthenticated()
        {
            return !string.IsNullOrEmpty(_token);
        }

        public string? GetToken()
        {
            return _token;
        }

        public string? GetUserName()
        {
            return _userName;
        }

        public void Logout()
        {
            _token = null;
            _refreshToken = null;
            _userName = null;
            ClearTokenStorage();
        }

        private string? GetUserNameFromToken(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                return jwtToken.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;
            }
            catch
            {
                return null;
            }
        }

        private void SaveTokenToStorage()
        {
            AppSettings.Default.Token = _token ?? "";
            AppSettings.Default.RefreshToken = _refreshToken ?? "";
            AppSettings.Default.UserName = _userName ?? "";
            AppSettings.Default.Save();
        }

        private void LoadTokenFromStorage()
        {
            _token = AppSettings.Default.Token;
            _refreshToken = AppSettings.Default.RefreshToken;
            _userName = AppSettings.Default.UserName;

            if (string.IsNullOrEmpty(_token))
            {
                _token = null;
                _refreshToken = null;
                _userName = null;
            }
        }

        private void ClearTokenStorage()
        {
            AppSettings.Default.Token = "";
            AppSettings.Default.RefreshToken = "";
            AppSettings.Default.UserName = "";
            AppSettings.Default.Save();
        }
    }
}