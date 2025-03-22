using SMSystem.Desktop.Models;
using SMSystem.Desktop.Services.Interfaces;

namespace SMSystem.Desktop.Forms
{
    public partial class LoginForm : BaseForm
    {
        private readonly IAuthService _authService;

        public LoginForm(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;

            if (_authService.IsAuthenticated())
            {
                OpenMainForm(this);
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBoxShow.Warning("Lütfen email ve şifre alanlarını doldurunuz.");
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "Giriş yapılıyor...";

            try
            {
                bool result = await _authService.LoginAsync(txtEmail.Text, txtPassword.Text);

                if (result)
                {
                    OpenMainForm(this);
                }
                else
                {
                    MessageBoxShow.Error("Giriş başarısız. Lütfen bilgilerinizi kontrol ediniz.");
                }
            }
            catch (Exception ex)
            {
                MessageBoxShow.Error($"Giriş sırasında bir hata oluştu: {ex.Message}");
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Giriş Yap";
            }
        }
    }
}