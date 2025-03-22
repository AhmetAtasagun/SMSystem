using System.ComponentModel;

namespace SMSystem.Desktop.Forms
{
    partial class SaleForm
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
            panel1 = new Panel();
            lblTitle = new Label();
            groupBoxSaleDetails = new GroupBox();
            numericQuantity = new NumericUpDown();
            numericPrice = new NumericUpDown();
            comboBoxProducts = new ComboBox();
            lblQuantity = new Label();
            lblPrice = new Label();
            lblProduct = new Label();
            btnClear = new Button();
            btnSave = new Button();
            dataGridViewSales = new DataGridView();
            btnListSales = new Button();
            btnEdit = new Button();
            btnNewSale = new Button();
            panel1.SuspendLayout();
            groupBoxSaleDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSales).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            panel1.Controls.Add(lblTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(875, 60);
            panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(12, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(129, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Satış Yönetimi";
            // 
            // groupBoxSaleDetails
            // 
            groupBoxSaleDetails.Controls.Add(numericQuantity);
            groupBoxSaleDetails.Controls.Add(numericPrice);
            groupBoxSaleDetails.Controls.Add(comboBoxProducts);
            groupBoxSaleDetails.Controls.Add(lblQuantity);
            groupBoxSaleDetails.Controls.Add(lblPrice);
            groupBoxSaleDetails.Controls.Add(lblProduct);
            groupBoxSaleDetails.Controls.Add(btnClear);
            groupBoxSaleDetails.Controls.Add(btnSave);
            groupBoxSaleDetails.Location = new Point(12, 66);
            groupBoxSaleDetails.Name = "groupBoxSaleDetails";
            groupBoxSaleDetails.Size = new Size(851, 120);
            groupBoxSaleDetails.TabIndex = 1;
            groupBoxSaleDetails.TabStop = false;
            groupBoxSaleDetails.Text = "Satış Detayları";
            // 
            // numericQuantity
            // 
            numericQuantity.Location = new Point(550, 51);
            numericQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericQuantity.Name = "numericQuantity";
            numericQuantity.Size = new Size(120, 23);
            numericQuantity.TabIndex = 7;
            numericQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericPrice
            // 
            numericPrice.DecimalPlaces = 2;
            numericPrice.Location = new Point(320, 51);
            numericPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericPrice.Name = "numericPrice";
            numericPrice.Size = new Size(120, 23);
            numericPrice.TabIndex = 6;
            // 
            // comboBoxProducts
            // 
            comboBoxProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProducts.FormattingEnabled = true;
            comboBoxProducts.Location = new Point(90, 51);
            comboBoxProducts.Name = "comboBoxProducts";
            comboBoxProducts.Size = new Size(150, 23);
            comboBoxProducts.TabIndex = 5;
            comboBoxProducts.SelectedIndexChanged += comboBoxProducts_SelectedIndexChanged;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(500, 54);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(44, 15);
            lblQuantity.TabIndex = 4;
            lblQuantity.Text = "Miktar:";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(280, 54);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(35, 15);
            lblPrice.TabIndex = 3;
            lblPrice.Text = "Fiyat:";
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Location = new Point(50, 54);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(36, 15);
            lblProduct.TabIndex = 2;
            lblProduct.Text = "Ürün:";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(220, 53, 69);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(680, 80);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 30);
            btnClear.TabIndex = 1;
            btnClear.Text = "Temizle";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(40, 167, 69);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(770, 80);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 30);
            btnSave.TabIndex = 0;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // dataGridViewSales
            // 
            dataGridViewSales.AllowUserToAddRows = false;
            dataGridViewSales.AllowUserToDeleteRows = false;
            dataGridViewSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSales.BackgroundColor = SystemColors.Control;
            dataGridViewSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSales.Location = new Point(12, 228);
            dataGridViewSales.MultiSelect = false;
            dataGridViewSales.Name = "dataGridViewSales";
            dataGridViewSales.ReadOnly = true;
            dataGridViewSales.RowTemplate.Height = 25;
            dataGridViewSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSales.Size = new Size(851, 250);
            dataGridViewSales.TabIndex = 2;
            dataGridViewSales.CellClick += dataGridViewSales_CellClick;
            // 
            // btnListSales
            // 
            btnListSales.BackColor = Color.FromArgb(23, 162, 184);
            btnListSales.FlatStyle = FlatStyle.Flat;
            btnListSales.ForeColor = Color.White;
            btnListSales.Location = new Point(788, 192);
            btnListSales.Name = "btnListSales";
            btnListSales.Size = new Size(75, 30);
            btnListSales.TabIndex = 3;
            btnListSales.Text = "Listele";
            btnListSales.UseVisualStyleBackColor = false;
            btnListSales.Click += btnListSales_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(255, 193, 7);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(707, 192);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 30);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Düzenle";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnNewSale
            // 
            btnNewSale.BackColor = Color.FromArgb(0, 123, 255);
            btnNewSale.FlatStyle = FlatStyle.Flat;
            btnNewSale.ForeColor = Color.White;
            btnNewSale.Location = new Point(626, 192);
            btnNewSale.Name = "btnNewSale";
            btnNewSale.Size = new Size(75, 30);
            btnNewSale.TabIndex = 5;
            btnNewSale.Text = "Yeni Satış";
            btnNewSale.UseVisualStyleBackColor = false;
            btnNewSale.Click += btnNewSale_Click;
            // 
            // SaleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 490);
            Controls.Add(btnNewSale);
            Controls.Add(btnEdit);
            Controls.Add(btnListSales);
            Controls.Add(dataGridViewSales);
            Controls.Add(groupBoxSaleDetails);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SaleForm";
            Text = "Satış Yönetimi";
            Load += SaleForm_Load;
            panel1.ResumeLayout(false);
            groupBoxSaleDetails.ResumeLayout(false);
            groupBoxSaleDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBoxSaleDetails;
        private System.Windows.Forms.NumericUpDown numericQuantity;
        private System.Windows.Forms.NumericUpDown numericPrice;
        private System.Windows.Forms.ComboBox comboBoxProducts;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dataGridViewSales;
        private System.Windows.Forms.Button btnListSales;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNewSale;
    }
}