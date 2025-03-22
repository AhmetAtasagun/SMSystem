using SMSystem.Desktop.Models;
using SMSystem.Desktop.Services.Interfaces;

namespace SMSystem.Desktop.Forms
{
    public partial class MainForm : BaseForm
    {
        private readonly IAuthService _authService;

        public MainForm(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
            UpdateUserInfo();
        }

        private void UpdateUserInfo()
        {
            string userName = _authService.GetUserName() ?? "Bilinmeyen Kullanıcı";
            lblUserStatus.Text = $"Kullanıcı: {userName}";
        }

        private void saleMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<SaleForm>(panelContent);
        }

        private void productsMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<ProductsForm>(panelContent);
        }

        private void categoriesMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<CategoriesForm>(panelContent);
        }

        private void inventoryMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<InventoryForm>(panelContent);
        }

        private void logoutMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBoxShow.Confirm("Çıkış yapmak istediğinize emin misiniz?", "Çıkış"))
            {
                _authService.Logout();
                this.Close();
            }
        }
    }
}