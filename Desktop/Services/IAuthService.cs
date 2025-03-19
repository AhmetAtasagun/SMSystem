using Newtonsoft.Json;
using SMSystem.Domain.Models.AuthModels;
using System.IdentityModel.Tokens.Jwt;

namespace SMSystem.Desktop.Services
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
            var response = await _apiService.PostAsync<dynamic>("auth/login", loginModel);

            if (response == null) return false;

            var responseStr = JsonConvert.SerializeObject(response);
            var authResponse = JsonConvert.DeserializeObject<AuthResponse>(responseStr);

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

            var responseStr = JsonConvert.SerializeObject(response);
            var authResponse = JsonConvert.DeserializeObject<AuthResponse>(responseStr);

            return authResponse?.IsSuccess == true;
        }

        public async Task<bool> RefreshTokenAsync()
        {
            if (string.IsNullOrEmpty(_refreshToken)) return false;

            var refreshModel = new { RefreshToken = _refreshToken };
            var response = await _apiService.PostAsync<dynamic>("auth/refresh-token", refreshModel);

            if (response == null) return false;

            var responseStr = JsonConvert.SerializeObject(response);
            var authResponse = JsonConvert.DeserializeObject<AuthResponse>(responseStr);

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
                return jwtToken.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
            }
            catch
            {
                return null;
            }
        }

        private void SaveTokenToStorage()
        {
            Properties.Settings.Default.Token = _token ?? "";
            Properties.Settings.Default.RefreshToken = _refreshToken ?? "";
            Properties.Settings.Default.UserName = _userName ?? "";
            Properties.Settings.Default.Save();
        }

        private void LoadTokenFromStorage()
        {
            _token = Properties.Settings.Default.Token;
            _refreshToken = Properties.Settings.Default.RefreshToken;
            _userName = Properties.Settings.Default.UserName;

            if (string.IsNullOrEmpty(_token))
            {
                _token = null;
                _refreshToken = null;
                _userName = null;
            }
        }

        private void ClearTokenStorage()
        {
            Properties.Settings.Default.Token = "";
            Properties.Settings.Default.RefreshToken = "";
            Properties.Settings.Default.UserName = "";
            Properties.Settings.Default.Save();
        }
    }
}