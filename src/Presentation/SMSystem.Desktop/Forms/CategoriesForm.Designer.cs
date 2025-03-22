namespace SMSystem.Desktop.Forms
{
    partial class CategoriesForm
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
            dgvCategories = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colParent = new DataGridViewTextBoxColumn();
            panelForm = new Panel();
            lblTitle = new Label();
            lblName = new Label();
            txtName = new TextBox();
            lblParent = new Label();
            cmbParent = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            btnDelete = new Button();
            btnNew = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
            panelForm.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCategories
            // 
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.AllowUserToDeleteRows = false;
            dgvCategories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategories.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colParent });
            dgvCategories.Location = new Point(10, 9);
            dgvCategories.Margin = new Padding(3, 2, 3, 2);
            dgvCategories.MultiSelect = false;
            dgvCategories.Name = "dgvCategories";
            dgvCategories.ReadOnly = true;
            dgvCategories.RowHeadersWidth = 51;
            dgvCategories.RowTemplate.Height = 29;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.Size = new Size(394, 282);
            dgvCategories.TabIndex = 0;
            dgvCategories.CellClick += dgvCategories_CellClick;
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
            colName.HeaderText = "Kategori Adı";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 200;
            // 
            // colParent
            // 
            colParent.DataPropertyName = "ParentName";
            colParent.HeaderText = "Üst Kategori";
            colParent.MinimumWidth = 6;
            colParent.Name = "colParent";
            colParent.ReadOnly = true;
            colParent.Width = 200;
            // 
            // panelForm
            // 
            panelForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelForm.Controls.Add(btnNew);
            panelForm.Controls.Add(lblTitle);
            panelForm.Controls.Add(lblName);
            panelForm.Controls.Add(txtName);
            panelForm.Controls.Add(lblParent);
            panelForm.Controls.Add(cmbParent);
            panelForm.Controls.Add(btnSave);
            panelForm.Controls.Add(btnCancel);
            panelForm.Controls.Add(btnDelete);
            panelForm.Location = new Point(410, 9);
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
            lblTitle.Size = new Size(139, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Kategori Bilgileri";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(9, 38);
            lblName.Name = "lblName";
            lblName.Size = new Size(75, 15);
            lblName.TabIndex = 1;
            lblName.Text = "Kategori Adı:";
            // 
            // txtName
            // 
            txtName.Location = new Point(9, 55);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(263, 23);
            txtName.TabIndex = 2;
            // 
            // lblParent
            // 
            lblParent.AutoSize = true;
            lblParent.Location = new Point(9, 82);
            lblParent.Name = "lblParent";
            lblParent.Size = new Size(74, 15);
            lblParent.TabIndex = 3;
            lblParent.Text = "Üst Kategori:";
            // 
            // cmbParent
            // 
            cmbParent.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbParent.FormattingEnabled = true;
            cmbParent.Location = new Point(9, 100);
            cmbParent.Margin = new Padding(3, 2, 3, 2);
            cmbParent.Name = "cmbParent";
            cmbParent.Size = new Size(263, 23);
            cmbParent.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(9, 135);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(82, 22);
            btnSave.TabIndex = 5;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(96, 135);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(82, 22);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "İptal";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(184, 135);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(82, 22);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(184, 7);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(82, 22);
            btnNew.TabIndex = 8;
            btnNew.Text = "Yeni";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // CategoriesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 300);
            Controls.Add(dgvCategories);
            Controls.Add(panelForm);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CategoriesForm";
            Text = "Kategori Yönetimi";
            Load += CategoriesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParent;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.ComboBox cmbParent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
    }
}