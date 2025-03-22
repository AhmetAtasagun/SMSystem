using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSystem.Desktop.Forms
{
    partial class ProductsForm
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
            dgvProducts = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            panelForm = new Panel();
            btnNew = new Button();
            lblTitle = new Label();
            lblName = new Label();
            txtName = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblPrice = new Label();
            numPrice = new NumericUpDown();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            btnDelete = new Button();
            pictureBoxImage = new PictureBox();
            btnSelectImage = new Button();
            lblImage = new Label();
            ((ISupportInitialize)dgvProducts).BeginInit();
            panelForm.SuspendLayout();
            ((ISupportInitialize)numPrice).BeginInit();
            ((ISupportInitialize)pictureBoxImage).BeginInit();
            SuspendLayout();
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colPrice, colCategory });
            dgvProducts.Location = new Point(10, 9);
            dgvProducts.Margin = new Padding(3, 2, 3, 2);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.RowTemplate.Height = 29;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(394, 282);
            dgvProducts.TabIndex = 0;
            dgvProducts.CellClick += dgvProducts_CellClick;
            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.HeaderText = "ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            colId.Width = 125;
            // 
            // colName
            // 
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Ürün Adı";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 150;
            // 
            // colPrice
            // 
            colPrice.DataPropertyName = "Price";
            colPrice.HeaderText = "Fiyat";
            colPrice.MinimumWidth = 6;
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            // 
            // colCategory
            // 
            colCategory.DataPropertyName = "CategoryName";
            colCategory.HeaderText = "Kategori";
            colCategory.MinimumWidth = 6;
            colCategory.Name = "colCategory";
            colCategory.ReadOnly = true;
            colCategory.Width = 125;
            // 
            // panelForm
            // 
            panelForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelForm.Controls.Add(btnNew);
            panelForm.Controls.Add(lblTitle);
            panelForm.Controls.Add(lblName);
            panelForm.Controls.Add(txtName);
            panelForm.Controls.Add(lblDescription);
            panelForm.Controls.Add(txtDescription);
            panelForm.Controls.Add(lblPrice);
            panelForm.Controls.Add(numPrice);
            panelForm.Controls.Add(lblCategory);
            panelForm.Controls.Add(cmbCategory);
            panelForm.Controls.Add(btnSave);
            panelForm.Controls.Add(btnCancel);
            panelForm.Controls.Add(btnDelete);
            panelForm.Controls.Add(pictureBoxImage);
            panelForm.Controls.Add(btnSelectImage);
            panelForm.Controls.Add(lblImage);
            panelForm.Location = new Point(410, 9);
            panelForm.Margin = new Padding(3, 2, 3, 2);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(454, 282);
            panelForm.TabIndex = 1;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(184, 7);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(82, 22);
            btnNew.TabIndex = 12;
            btnNew.Text = "Yeni";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(9, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(112, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Ürün Bilgileri";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(9, 38);
            lblName.Name = "lblName";
            lblName.Size = new Size(57, 15);
            lblName.TabIndex = 1;
            lblName.Text = "Ürün Adı:";
            // 
            // txtName
            // 
            txtName.Location = new Point(9, 55);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(263, 23);
            txtName.TabIndex = 2;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(9, 82);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(59, 15);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Açıklama:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(9, 100);
            txtDescription.Margin = new Padding(3, 2, 3, 2);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(263, 46);
            txtDescription.TabIndex = 4;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(9, 152);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(35, 15);
            lblPrice.TabIndex = 5;
            lblPrice.Text = "Fiyat:";
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(9, 170);
            numPrice.Margin = new Padding(3, 2, 3, 2);
            numPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(131, 23);
            numPrice.TabIndex = 6;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(9, 197);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(54, 15);
            lblCategory.TabIndex = 7;
            lblCategory.Text = "Kategori:";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(9, 214);
            cmbCategory.Margin = new Padding(3, 2, 3, 2);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(263, 23);
            cmbCategory.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(9, 248);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(82, 22);
            btnSave.TabIndex = 9;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(96, 248);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(82, 22);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "İptal";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(184, 248);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(82, 22);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // pictureBoxImage
            // 
            pictureBoxImage.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxImage.Location = new Point(286, 31);
            pictureBoxImage.Name = "pictureBoxImage";
            pictureBoxImage.Size = new Size(150, 150);
            pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImage.TabIndex = 13;
            pictureBoxImage.TabStop = false;
            // 
            // btnSelectImage
            // 
            btnSelectImage.Location = new Point(311, 191);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new Size(100, 30);
            btnSelectImage.TabIndex = 14;
            btnSelectImage.Text = "Resim Seç";
            btnSelectImage.Click += BtnSelectImage_Click;
            // 
            // lblImage
            // 
            lblImage.AutoSize = true;
            lblImage.Location = new Point(286, 11);
            lblImage.Name = "lblImage";
            lblImage.Size = new Size(71, 15);
            lblImage.TabIndex = 15;
            lblImage.Text = "Ürün Resmi:";
            // 
            // ProductsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 300);
            Controls.Add(dgvProducts);
            Controls.Add(panelForm);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ProductsForm";
            Text = "Ürün Yönetimi";
            Load += ProductsForm_Load;
            ((ISupportInitialize)dgvProducts).EndInit();
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ((ISupportInitialize)numPrice).EndInit();
            ((ISupportInitialize)pictureBoxImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.Label lblImage;
    }
}