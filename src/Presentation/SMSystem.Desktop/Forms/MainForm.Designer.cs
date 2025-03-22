namespace SMSystem.Desktop.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            productsMenuItem = new ToolStripMenuItem();
            categoriesMenuItem = new ToolStripMenuItem();
            inventoryMenuItem = new ToolStripMenuItem();
            logoutMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            lblUserStatus = new ToolStripStatusLabel();
            panelContent = new Panel();
            lblWelcome = new Label();
            saleMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { saleMenuItem, productsMenuItem, categoriesMenuItem, inventoryMenuItem, logoutMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(5, 2, 0, 2);
            menuStrip.Size = new Size(875, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // productsMenuItem
            // 
            productsMenuItem.Name = "productsMenuItem";
            productsMenuItem.Size = new Size(58, 20);
            productsMenuItem.Text = "Ürünler";
            productsMenuItem.Click += productsMenuItem_Click;
            // 
            // categoriesMenuItem
            // 
            categoriesMenuItem.Name = "categoriesMenuItem";
            categoriesMenuItem.Size = new Size(76, 20);
            categoriesMenuItem.Text = "Kategoriler";
            categoriesMenuItem.Click += categoriesMenuItem_Click;
            // 
            // inventoryMenuItem
            // 
            inventoryMenuItem.Name = "inventoryMenuItem";
            inventoryMenuItem.Size = new Size(42, 20);
            inventoryMenuItem.Text = "Stok";
            inventoryMenuItem.Click += inventoryMenuItem_Click;
            // 
            // logoutMenuItem
            // 
            logoutMenuItem.Alignment = ToolStripItemAlignment.Right;
            logoutMenuItem.Name = "logoutMenuItem";
            logoutMenuItem.Size = new Size(66, 20);
            logoutMenuItem.Text = "Çıkış Yap";
            logoutMenuItem.Click += logoutMenuItem_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { lblUserStatus });
            statusStrip.Location = new Point(0, 316);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 12, 0);
            statusStrip.Size = new Size(875, 22);
            statusStrip.TabIndex = 1;
            statusStrip.Text = "statusStrip1";
            // 
            // lblUserStatus
            // 
            lblUserStatus.Name = "lblUserStatus";
            lblUserStatus.Size = new Size(136, 17);
            lblUserStatus.Text = "Kullanıcı: Giriş yapılmadı";
            // 
            // panelContent
            // 
            panelContent.Controls.Add(lblWelcome);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 24);
            panelContent.Margin = new Padding(3, 2, 3, 2);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(875, 292);
            panelContent.TabIndex = 2;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblWelcome.Location = new Point(303, 120);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(266, 30);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Mağaza Yönetim Sistemi";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // saleMenuItem
            // 
            saleMenuItem.Name = "saleMenuItem";
            saleMenuItem.Size = new Size(43, 20);
            saleMenuItem.Text = "Satış";
            saleMenuItem.Click += saleMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 338);
            Controls.Add(panelContent);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SM System - Ana Sayfa";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem productsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblUserStatus;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblWelcome;
        private ToolStripMenuItem saleMenuItem;
    }
}