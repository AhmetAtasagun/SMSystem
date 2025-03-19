using SMSystem.Desktop.Services;
using SMSystem.Domain.Dtos;

namespace SMSystem.Desktop.Forms
{
    public partial class CategoriesForm : Form
    {
        private readonly ICategoryService _categoryService;
        private List<CategoryDto> _categories = new List<CategoryDto>();
        private int? _selectedCategoryId = null;

        public CategoriesForm(ICategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;
            LoadData();
        }

        private void InitializeComponent()
        {
            this.dgvCategories = new DataGridView();
            this.colId = new DataGridViewTextBoxColumn();
            this.colName = new DataGridViewTextBoxColumn();
            this.colParent = new DataGridViewTextBoxColumn();
            this.panelForm = new Panel();
            this.lblTitle = new Label();
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblParent = new Label();
            this.cmbParent = new ComboBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.btnDelete = new Button();
            this.btnNew = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.panelForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left)));
            this.dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Columns.AddRange(new DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colParent});
            this.dgvCategories.Location = new Point(12, 12);
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.RowHeadersWidth = 51;
            this.dgvCategories.RowTemplate.Height = 29;
            this.dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.Size = new Size(450, 376);
            this.dgvCategories.TabIndex = 0;
            this.dgvCategories.CellClick += new DataGridViewCellEventHandler(this.dgvCategories_CellClick);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "ID";
            this.colId.MinimumWidth = 6;
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            this.colId.Width = 125;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Kategori Adı";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 200;
            // 
            // colParent
            // 
            this.colParent.DataPropertyName = "ParentName";
            this.colParent.HeaderText = "Üst Kategori";
            this.colParent.MinimumWidth = 6;
            this.colParent.Name = "colParent";
            this.colParent.ReadOnly = true;
            this.colParent.Width = 200;
            // 
            // panelForm
            // 
            this.panelForm.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            this.panelForm.Controls.Add(this.lblTitle);
            this.panelForm.Controls.Add(this.lblName);
            this.panelForm.Controls.Add(this.txtName);
            this.panelForm.Controls.Add(this.lblParent);
            this.panelForm.Controls.Add(this.cmbParent);
            this.panelForm.Controls.Add(this.btnSave);
            this.panelForm.Controls.Add(this.btnCancel);
            this.panelForm.Controls.Add(this.btnDelete);
            this.panelForm.Location = new Point(468, 12);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new Size(320, 376);
            this.panelForm.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitle.Location = new Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(180, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Kategori Bilgileri";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new Point(10, 50);
            this.lblName.Name = "lblName";
            this.lblName.Size = new Size(99, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Kategori Adı:";
            // 
            // txtName
            // 
            this.txtName.Location = new Point(10, 73);
            this.txtName.Name = "txtName";
            this.txtName.Size = new Size(300, 27);
            this.txtName.TabIndex = 2;
            // 
            // lblParent
            // 
            this.lblParent.AutoSize = true;
            this.lblParent.Location = new Point(10, 110);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new Size(95, 20);
            this.lblParent.TabIndex = 3;
            this.lblParent.Text = "Üst Kategori:";
            // 
            // cmbParent
            // 
            this.cmbParent.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbParent.FormattingEnabled = true;
            this.cmbParent.Location = new Point(10, 133);
            this.cmbParent.Name = "cmbParent";
            this.cmbParent.Size = new Size(300, 28);
            this.cmbParent.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new Point(10, 180);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(94, 29);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new Point(110, 180);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(94, 29);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new Point(210, 180);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(94, 29);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new Point(368, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new Size(94, 29);
            this.btnNew.TabIndex = 8;
            this.btnNew.Text = "Yeni";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new EventHandler(this.btnNew_Click);
            // 
            // CategoriesForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 400);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgvCategories);
            this.Controls.Add(this.panelForm);
            this.Name = "CategoriesForm";
            this.Text = "Kategori Yönetimi";
            this.Load += new EventHandler(this.CategoriesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            this.ResumeLayout(false);
        }

        private DataGridView dgvCategories;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colParent;
        private Panel panelForm;
        private Label lblTitle;
        private Label lblName;
        private TextBox txtName;
        private Label lblParent;
        private ComboBox cmbParent;
        private Button btnSave;
        private Button btnCancel;
        private Button btnDelete;
        private Button btnNew;

        private async void LoadData()
        {
            try
            {
                // Load categories
                _categories = await _categoryService.GetAllCategoriesAsync();
                
                // Setup parent category dropdown
                var parentCategories = new List<CategoryDto>(_categories);
                parentCategories.Insert(0, new CategoryDto { Id = 0, Name = "-- Ana Kategori --" });
                
                cmbParent.DataSource = null;
                cmbParent.DisplayMember = "Name";
                cmbParent.ValueMember = "Id";
                cmbParent.DataSource = parentCategories;

                // Add ParentName property for display
                foreach (var category in _categories)
                {
                    if (category.ParentId.HasValue)
                    {
                        var parent = _categories.FirstOrDefault(c => c.Id == category.ParentId.Value);
                        category.ParentName = parent?.Name ?? "";
                    }
                    else
                    {
                        category.ParentName = "";
                    }
                }

                // Bind to grid
                dgvCategories.DataSource = null;
                dgvCategories.DataSource = _categories;

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtName.Text = "";
            if (cmbParent.Items.Count > 0)
                cmbParent.SelectedIndex = 0;

            _selectedCategoryId = null;
            btnDelete.Enabled = false;
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var category = _categories[e.RowIndex];
                _selectedCategoryId = category.Id;

                txtName.Text = category.Name;

                // Find and select the parent category
                if (category.ParentId.HasValue)
                {
                    for (int i = 0; i < cmbParent.Items.Count; i++)
                    {
                        var parentCategory = (CategoryDto)cmbParent.Items[i];
                        if (parentCategory.Id == category.ParentId.Value)
                        {
                            cmbParent.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    cmbParent.SelectedIndex = 0; // No parent
                }

                btnDelete.Enabled = true;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Lütfen kategori adını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedParentId = (int)cmbParent.SelectedValue;
                var category = new CategoryDto
                {
                    Name = txtName.Text,
                    ParentId = selectedParentId == 0 ? null : selectedParentId
                };

                if (_selectedCategoryId.HasValue)
                {
                    // Update existing category
                    category.Id = _selectedCategoryId.Value;
                    
                    // Check if trying to set parent to itself or its child
                    if (category.ParentId.HasValue && (category.ParentId.Value == category.Id || IsChildCategory(category.Id, category.ParentId.Value)))
                    {
                        MessageBox.Show("Bir kategori kendisini veya alt kategorisini üst kategori olarak seçemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    
                    var result = await _categoryService.UpdateCategoryAsync(category);

                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Kategori başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show($"Kategori güncellenirken hata oluştu: {result.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Create new category
                    var result = await _categoryService.CreateCategoryAsync(category);

                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Kategori başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show($"Kategori eklenirken hata oluştu: {result.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşlem sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_selectedCategoryId.HasValue) return;

            if (MessageBox.Show("Seçili kategoriyi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var result = await _categoryService.DeleteCategoryAsync(_selectedCategoryId.Value);

                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Kategori başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show($"Kategori silinirken hata oluştu: {result.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"İşlem sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private bool IsChildCategory(int parentId, int childId)
        {
            // Check if childId is a child or descendant of parentId
            var child = _categories.FirstOrDefault(c => c.Id == childId);
            if (child == null) return false;

            if (child.ParentId.HasValue)
            {
                if (child.ParentId.Value == parentId) return true;
                return IsChildCategory(parentId, child.ParentId.Value);
            }

            return false;
        }
    }
}