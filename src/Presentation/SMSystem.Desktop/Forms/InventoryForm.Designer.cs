namespace SMSystem.Desktop.Forms
{
    partial class InventoryForm
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
            dgvInventory = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colProduct = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colProcess = new DataGridViewTextBoxColumn();
            colWarehouse = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            panelForm = new Panel();
            lblTitle = new Label();
            lblProduct = new Label();
            cmbProduct = new ComboBox();
            lblQuantity = new Label();
            numQuantity = new NumericUpDown();
            lblProcess = new Label();
            cmbProcess = new ComboBox();
            lblWarehouse = new Label();
            txtWarehouse = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            btnDelete = new Button();
            btnNew = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            SuspendLayout();
            // 
            // dgvInventory
            // 
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.AllowUserToDeleteRows = false;
            dgvInventory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventory.Columns.AddRange(new DataGridViewColumn[] { colId, colProduct, colQuantity, colProcess, colWarehouse, colDate });
            dgvInventory.Location = new Point(10, 9);
            dgvInventory.Margin = new Padding(3, 2, 3, 2);
            dgvInventory.MultiSelect = false;
            dgvInventory.Name = "dgvInventory";
            dgvInventory.ReadOnly = true;
            dgvInventory.RowHeadersWidth = 51;
            dgvInventory.RowTemplate.Height = 29;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.Size = new Size(481, 282);
            dgvInventory.TabIndex = 0;
            dgvInventory.CellClick += dgvInventory_CellClick;
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
            // colProduct
            // 
            colProduct.DataPropertyName = "ProductName";
            colProduct.HeaderText = "Ürün";
            colProduct.MinimumWidth = 6;
            colProduct.Name = "colProduct";
            colProduct.ReadOnly = true;
            colProduct.Width = 150;
            // 
            // colQuantity
            // 
            colQuantity.DataPropertyName = "Quantity";
            colQuantity.HeaderText = "Miktar";
            colQuantity.MinimumWidth = 6;
            colQuantity.Name = "colQuantity";
            colQuantity.ReadOnly = true;
            colQuantity.Width = 80;
            // 
            // colProcess
            // 
            colProcess.DataPropertyName = "ProcessText";
            colProcess.HeaderText = "İşlem";
            colProcess.MinimumWidth = 6;
            colProcess.Name = "colProcess";
            colProcess.ReadOnly = true;
            // 
            // colWarehouse
            // 
            colWarehouse.DataPropertyName = "WarehouseName";
            colWarehouse.HeaderText = "Depo";
            colWarehouse.MinimumWidth = 6;
            colWarehouse.Name = "colWarehouse";
            colWarehouse.ReadOnly = true;
            // 
            // colDate
            // 
            colDate.DataPropertyName = "CreatedDate";
            colDate.HeaderText = "Tarih";
            colDate.MinimumWidth = 6;
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            colDate.Width = 120;
            // 
            // panelForm
            // 
            panelForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelForm.Controls.Add(btnNew);
            panelForm.Controls.Add(lblTitle);
            panelForm.Controls.Add(lblProduct);
            panelForm.Controls.Add(cmbProduct);
            panelForm.Controls.Add(lblQuantity);
            panelForm.Controls.Add(numQuantity);
            panelForm.Controls.Add(lblProcess);
            panelForm.Controls.Add(cmbProcess);
            panelForm.Controls.Add(lblWarehouse);
            panelForm.Controls.Add(txtWarehouse);
            panelForm.Controls.Add(btnSave);
            panelForm.Controls.Add(btnCancel);
            panelForm.Controls.Add(btnDelete);
            panelForm.Location = new Point(497, 9);
            panelForm.Margin = new Padding(3, 2, 3, 2);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(280, 282);
            panelForm.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(9, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(113, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Stok Hareketi";
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Location = new Point(9, 38);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(36, 15);
            lblProduct.TabIndex = 1;
            lblProduct.Text = "Ürün:";
            // 
            // cmbProduct
            // 
            cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProduct.FormattingEnabled = true;
            cmbProduct.Location = new Point(9, 55);
            cmbProduct.Margin = new Padding(3, 2, 3, 2);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(263, 23);
            cmbProduct.TabIndex = 2;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(9, 82);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(44, 15);
            lblQuantity.TabIndex = 3;
            lblQuantity.Text = "Miktar:";
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(9, 100);
            numQuantity.Margin = new Padding(3, 2, 3, 2);
            numQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(131, 23);
            numQuantity.TabIndex = 4;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblProcess
            // 
            lblProcess.AutoSize = true;
            lblProcess.Location = new Point(9, 128);
            lblProcess.Name = "lblProcess";
            lblProcess.Size = new Size(38, 15);
            lblProcess.TabIndex = 5;
            lblProcess.Text = "İşlem:";
            // 
            // cmbProcess
            // 
            cmbProcess.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProcess.FormattingEnabled = true;
            cmbProcess.Location = new Point(9, 145);
            cmbProcess.Margin = new Padding(3, 2, 3, 2);
            cmbProcess.Name = "cmbProcess";
            cmbProcess.Size = new Size(263, 23);
            cmbProcess.TabIndex = 6;
            // 
            // lblWarehouse
            // 
            lblWarehouse.AutoSize = true;
            lblWarehouse.Location = new Point(9, 172);
            lblWarehouse.Name = "lblWarehouse";
            lblWarehouse.Size = new Size(38, 15);
            lblWarehouse.TabIndex = 7;
            lblWarehouse.Text = "Depo:";
            // 
            // txtWarehouse
            // 
            txtWarehouse.Location = new Point(9, 190);
            txtWarehouse.Margin = new Padding(3, 2, 3, 2);
            txtWarehouse.Name = "txtWarehouse";
            txtWarehouse.Size = new Size(263, 23);
            txtWarehouse.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(9, 225);
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
            btnCancel.Location = new Point(96, 225);
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
            btnDelete.Location = new Point(184, 225);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(82, 22);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(190, 7);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(82, 22);
            btnNew.TabIndex = 12;
            btnNew.Text = "Yeni";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // InventoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(788, 300);
            Controls.Add(dgvInventory);
            Controls.Add(panelForm);
            Margin = new Padding(3, 2, 3, 2);
            Name = "InventoryForm";
            Text = "Stok Yönetimi";
            Load += InventoryForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcess;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWarehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.ComboBox cmbProcess;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.TextBox txtWarehouse;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
    }
}