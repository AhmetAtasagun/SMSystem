using SMSystem.Desktop.Services;
using SMSystem.Domain.Dtos;

namespace SMSystem.Desktop.Forms
{
    public partial class ProductsForm : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private List<ProductDto> _products = new List<ProductDto>();
        private List<CategoryDto> _categories = new List<CategoryDto>();
        private int? _selectedProductId = null;

        public ProductsForm(IProductService productService, ICategoryService categoryService)
        {
            InitializeComponent();
            _productService = productService;
            _categoryService = categoryService;
            LoadData();
        }

        private void InitializeComponent()
        {
            this.dgvProducts = new DataGridView();
            this.colId = new DataGridViewTextBoxColumn();
            this.colName = new DataGridViewTextBoxColumn();
            this.colPrice = new DataGridViewTextBoxColumn();
            this.colCategory = new DataGridViewTextBoxColumn();
            this.panelForm = new Panel();
            this.lblTitle = new Label();
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblDescription = new Label();
            this.txtDescription = new TextBox();
            this.lblPrice = new Label();
            this.numPrice = new NumericUpDown();
            this.lblCategory = new Label();
            this.cmbCategory = new ComboBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.btnDelete = new Button();
            this.btnNew = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left)));
            this.dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colPrice,
            this.colCategory});
            this.dgvProducts.Location = new Point(12, 12);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 29;
            this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new Size(450, 376);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.CellClick += new DataGridViewCellEventHandler(this.dgvProducts_CellClick);
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
            this.colName.HeaderText = "Ürün Adı";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 150;
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "Price";
            this.colPrice.HeaderText = "Fiyat";
            this.colPrice.MinimumWidth = 6;
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 100;
            // 
            // colCategory
            // 
            this.colCategory.DataPropertyName = "CategoryName";
            this.colCategory.HeaderText = "Kategori";
            this.colCategory.MinimumWidth = 6;
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 125;
            // 
            // panelForm
            // 
            this.panelForm.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            this.panelForm.Controls.Add(this.lblTitle);
            this.panelForm.Controls.Add(this.lblName);
            this.panelForm.Controls.Add(this.txtName);
            this.panelForm.Controls.Add(this.lblDescription);
            this.panelForm.Controls.Add(this.txtDescription);
            this.panelForm.Controls.Add(this.lblPrice);
            this.panelForm.Controls.Add(this.numPrice);
            this.panelForm.Controls.Add(this.lblCategory);
            this.panelForm.Controls.Add(this.cmbCategory);
            this.panelForm.Controls.Add(this.btnSave);
            this.panelForm.Controls.Add(this.btnCancel);
            this.panelForm.Controls.Add(this.btnDelete);
            this.panelForm.Controls.Add(this.btnNew);
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
            this.lblTitle.Size = new Size(150, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Ürün Bilgileri";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new Point(10, 50);
            this.lblName.Name = "lblName";
            this.lblName.Size = new Size(73, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Ürün Adı:";
            // 
            // txtName
            // 
            this.txtName.Location = new Point(10, 73);
            this.txtName.Name = "txtName";
            this.txtName.Size = new Size(300, 27);
            this.txtName.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new Point(10, 110);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new Size(73, 20);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Açıklama:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new Point(10, 133);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new Size(300, 60);
            this.txtDescription.TabIndex = 4;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new Point(10, 203);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new Size(43, 20);
            this.lblPrice.TabIndex = 5;
            this.lblPrice.Text = "Fiyat:";
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new Point(10, 226);
            this.numPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new Size(150, 27);
            this.numPrice.TabIndex = 6;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new Point(10, 263);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new Size(69, 20);
            this.lblCategory.TabIndex = 7;
            this.lblCategory.Text = "Kategori:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new Point(10, 286);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new Size(300, 28);
            this.cmbCategory.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new Point(10, 330);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(94, 29);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new Point(110, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(94, 29);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new Point(210, 330);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(94, 29);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new Point(368, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new Size(94, 29);
            this.btnNew.TabIndex = 12;
            this.btnNew.Text = "Yeni";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new EventHandler(this.btnNew_Click);
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 400);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.panelForm);
            this.Name = "ProductsForm";
            this.Text = "Ürün Yönetimi";
            this.Load += new EventHandler(this.ProductsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.ResumeLayout(false);
        }

        private DataGridView dgvProducts;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colCategory;
        private Panel panelForm;
        private Label lblTitle;
        private Label lblName;
        private TextBox txtName;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblPrice;
        private NumericUpDown numPrice;
        private Label lblCategory;
        private ComboBox cmbCategory;
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
                cmbCategory.DataSource = null;
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "Id";
                cmbCategory.DataSource = _categories;

                // Load products
                _products = await _productService.GetAllProductsAsync();
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = _products;

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
            txtDescription.Text = "";
            numPrice.Value = 0;
            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;

            _selectedProductId = null;
            btnDelete.Enabled = false;
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var product = _products[e.RowIndex];
                _selectedProductId = product.Id;

                txtName.Text = product.Name;
                txtDescription.Text = product.Description;
                numPrice.Value = product.Price;

                // Find and select the category
                for (int i = 0; i < cmbCategory.Items.Count; i++)
                {
                    var category = (CategoryDto)cmbCategory.Items[i];
                    if (category.Id == product.CategoryId)
                    {
                        cmbCategory.SelectedIndex = i;
                        break;
                    }
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
                MessageBox.Show("Lütfen ürün adını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir kategori seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var product = new ProductDto
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    Price = numPrice.Value,
                    CategoryId = ((CategoryDto)cmbCategory.SelectedItem).Id
                };

                if (_selectedProductId.HasValue)
                {
                    // Update existing product
                    product.Id = _selectedProductId.Value;
                    var result = await _productService.UpdateProductAsync(product);

                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Ürün başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show($"Ürün güncellenirken hata oluştu: {result.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Create new product
                    var result = await _productService.CreateProductAsync(product);

                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Ürün başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show($"Ürün eklenirken hata oluştu: {result.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (!_selectedProductId.HasValue) return;

            if (MessageBox.Show("Seçili ürünü silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var result = await _productService.DeleteProductAsync(_selectedProductId.Value);

                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Ürün başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show($"Ürün silinirken hata oluştu: {result.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"İşlem sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}