using SMSystem.Desktop.Services;

namespace SMSystem.Desktop.Forms
{
    public partial class MainForm : Form
    {
        private readonly IAuthService _authService;

        public MainForm(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
            UpdateUserInfo();
        }

        private void InitializeComponent()
        {
            this.menuStrip = new MenuStrip();
            this.productsMenuItem = new ToolStripMenuItem();
            this.categoriesMenuItem = new ToolStripMenuItem();
            this.inventoryMenuItem = new ToolStripMenuItem();
            this.logoutMenuItem = new ToolStripMenuItem();
            this.statusStrip = new StatusStrip();
            this.lblUserStatus = new ToolStripStatusLabel();
            this.panelContent = new Panel();
            this.lblWelcome = new Label();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new Size(20, 20);
            this.menuStrip.Items.AddRange(new ToolStripItem[] {
            this.productsMenuItem,
            this.categoriesMenuItem,
            this.inventoryMenuItem,
            this.logoutMenuItem});
            this.menuStrip.Location = new Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new Size(800, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // productsMenuItem
            // 
            this.productsMenuItem.Name = "productsMenuItem";
            this.productsMenuItem.Size = new Size(81, 24);
            this.productsMenuItem.Text = "Ürünler";
            this.productsMenuItem.Click += new EventHandler(this.productsMenuItem_Click);
            // 
            // categoriesMenuItem
            // 
            this.categoriesMenuItem.Name = "categoriesMenuItem";
            this.categoriesMenuItem.Size = new Size(100, 24);
            this.categoriesMenuItem.Text = "Kategoriler";
            this.categoriesMenuItem.Click += new EventHandler(this.categoriesMenuItem_Click);
            // 
            // inventoryMenuItem
            // 
            this.inventoryMenuItem.Name = "inventoryMenuItem";
            this.inventoryMenuItem.Size = new Size(53, 24);
            this.inventoryMenuItem.Text = "Stok";
            this.inventoryMenuItem.Click += new EventHandler(this.inventoryMenuItem_Click);
            // 
            // logoutMenuItem
            // 
            this.logoutMenuItem.Alignment = ToolStripItemAlignment.Right;
            this.logoutMenuItem.Name = "logoutMenuItem";
            this.logoutMenuItem.Size = new Size(91, 24);
            this.logoutMenuItem.Text = "Çıkış Yap";
            this.logoutMenuItem.Click += new EventHandler(this.logoutMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new Size(20, 20);
            this.statusStrip.Items.AddRange(new ToolStripItem[] {
            this.lblUserStatus});
            this.statusStrip.Location = new Point(0, 428);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new Size(800, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblUserStatus
            // 
            this.lblUserStatus.Name = "lblUserStatus";
            this.lblUserStatus.Size = new Size(151, 17);
            this.lblUserStatus.Text = "Kullanıcı: Giriş yapılmadı";
            // 
            // panelContent
            // 
            this.panelContent.Dock = DockStyle.Fill;
            this.panelContent.Location = new Point(0, 28);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new Size(800, 400);
            this.panelContent.TabIndex = 2;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblWelcome.Location = new Point(200, 150);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new Size(400, 37);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "SM System Yönetim Paneli";
            this.lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "SM System - Ana Sayfa";
            this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
            this.panelContent.Controls.Add(this.lblWelcome);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MenuStrip menuStrip;
        private ToolStripMenuItem productsMenuItem;
        private ToolStripMenuItem categoriesMenuItem;
        private ToolStripMenuItem inventoryMenuItem;
        private ToolStripMenuItem logoutMenuItem;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblUserStatus;
        private Panel panelContent;
        private Label lblWelcome;

        private void UpdateUserInfo()
        {
            string userName = _authService.GetUserName() ?? "Bilinmeyen Kullanıcı";
            lblUserStatus.Text = $"Kullanıcı: {userName}";
        }

        private void productsMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<ProductsForm>();
        }

        private void categoriesMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<CategoriesForm>();
        }

        private void inventoryMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<InventoryForm>();
        }

        private void logoutMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _authService.Logout();
                this.Close();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Form kapatılırken yapılacak işlemler
        }

        private void OpenChildForm<T>() where T : Form
        {
            var form = Program.ServiceProvider.GetRequiredService<T>();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            
            panelContent.Controls.Clear();
            panelContent.Controls.Add(form);
            form.Show();
        }
    }
}