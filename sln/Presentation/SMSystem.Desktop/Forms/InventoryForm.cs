using SMSystem.Desktop.Services;
using SMSystem.Domain.Dtos;
using SMSystem.Domain.Enums;

namespace SMSystem.Desktop.Forms
{
    public partial class InventoryForm : Form
    {
        private readonly IInventoryService _inventoryService;
        private readonly IProductService _productService;
        private List<InventoryDto> _inventories = new List<InventoryDto>();
        private List<ProductDto> _products = new List<ProductDto>();
        private int? _selectedInventoryId = null;

        public InventoryForm(IInventoryService inventoryService, IProductService productService)
        {
            InitializeComponent();
            _inventoryService = inventoryService;
            _productService = productService;
            LoadData();
        }

        private void InitializeComponent()
        {
            this.dgvInventory = new DataGridView();
            this.colId = new DataGridViewTextBoxColumn();
            this.colProduct = new DataGridViewTextBoxColumn();
            this.colQuantity = new DataGridViewTextBoxColumn();
            this.colProcess = new DataGridViewTextBoxColumn();
            this.colWarehouse = new DataGridViewTextBoxColumn();
            this.colDate = new DataGridViewTextBoxColumn();
            this.panelForm = new Panel();
            this.lblTitle = new Label();
            this.lblProduct = new Label();
            this.cmbProduct = new ComboBox();
            this.lblQuantity = new Label();
            this.numQuantity = new NumericUpDown();
            this.lblProcess = new Label();
            this.cmbProcess = new ComboBox();
            this.lblWarehouse = new Label();
            this.txtWarehouse = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.btnDelete = new Button();
            this.btnNew = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left)));
            this.dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Columns.AddRange(new DataGridViewColumn[] {
            this.colId,
            this.colProduct,
            this.colQuantity,
            this.colProcess,
            this.colWarehouse,
            this.colDate});
            this.dgvInventory.Location = new Point(12, 12);
            this.dgvInventory.MultiSelect = false;
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersWidth = 51;
            this.dgvInventory.RowTemplate.Height = 29;
            this.dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventory.Size = new Size(550, 376);
            this.dgvInventory.TabIndex = 0;
            this.dgvInventory.CellClick += new DataGridViewCellEventHandler(this.dgvInventory_CellClick);
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
            // colProduct
            // 
            this.colProduct.DataPropertyName = "ProductName";
            this.colProduct.HeaderText = "Ürün";
            this.colProduct.MinimumWidth = 6;
            this.colProduct.Name = "colProduct";
            this.colProduct.ReadOnly = true;
            this.colProduct.Width = 150;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.HeaderText = "Miktar";
            this.colQuantity.MinimumWidth = 6;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            this.colQuantity.Width = 80;
            // 
            // colProcess
            // 
            this.colProcess.DataPropertyName = "ProcessText";
            this.colProcess.HeaderText = "İşlem";
            this.colProcess.MinimumWidth = 6;
            this.colProcess.Name = "colProcess";
            this.colProcess.ReadOnly = true;
            this.colProcess.Width = 100;
            // 
            // colWarehouse
            // 
            this.colWarehouse.DataPropertyName = "WarehouseName";
            this.colWarehouse.HeaderText = "Depo";
            this.colWarehouse.MinimumWidth = 6;
            this.colWarehouse.Name = "colWarehouse";
            this.colWarehouse.ReadOnly = true;
            this.colWarehouse.Width = 100;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "CreatedDate";
            this.colDate.HeaderText = "Tarih";
            this.colDate.MinimumWidth = 6;
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 120;
            // 
            // panelForm
            // 
            this.panelForm.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            this.panelForm.Controls.Add(this.lblTitle);
            this.panelForm.Controls.Add(this.lblProduct);
            this.panelForm.Controls.Add(this.cmbProduct);
            this.panelForm.Controls.Add(this.lblQuantity);
            this.panelForm.Controls.Add(this.numQuantity);
            this.panelForm.Controls.Add(this.lblProcess);
            this.panelForm.Controls.Add(this.cmbProcess);
            this.panelForm.Controls.Add(this.lblWarehouse);
            this.panelForm.Controls.Add(this.txtWarehouse);
            this.panelForm.Controls.Add(this.btnSave);
            this.panelForm.Controls.Add(this.btnCancel);
            this.panelForm.Controls.Add(this.btnDelete);
            this.panelForm.Location = new Point(568, 12);
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
            this.lblTitle.Text = "Stok Hareketi";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new Point(10, 50);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new Size(46, 20);
            this.lblProduct.TabIndex = 1;
            this.lblProduct.Text = "Ürün:";
            // 
            // cmbProduct
            // 
            this.cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new Point(10, 73);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new Size(300, 28);
            this.cmbProduct.TabIndex = 2;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new Point(10, 110);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new Size(56, 20);
            this.lblQuantity.TabIndex = 3;
            this.lblQuantity.Text = "Miktar:";
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new Point(10, 133);
            this.numQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new Size(150, 27);
            this.numQuantity.TabIndex = 4;
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Location = new Point(10, 170);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new Size(48, 20);
            this.lblProcess.TabIndex = 5;
            this.lblProcess.Text = "İşlem:";
            // 
            // cmbProcess
            // 
            this.cmbProcess.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbProcess.FormattingEnabled = true;
            this.cmbProcess.Location = new Point(10, 193);
            this.cmbProcess.Name = "cmbProcess";
            this.cmbProcess.Size = new Size(300, 28);
            this.cmbProcess.TabIndex = 6;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new Point(10, 230);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new Size(48, 20);
            this.lblWarehouse.TabIndex = 7;
            this.lblWarehouse.Text = "Depo:";
            // 
            // txtWarehouse
            // 
            this.txtWarehouse.Location = new Point(10, 253);
            this.txtWarehouse.Name = "txtWarehouse";
            this.txtWarehouse.Size = new Size(300, 27);
            this.txtWarehouse.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new Point(10, 300);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(94, 29);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new Point(110, 300);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(94, 29);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new Point(210, 300);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(94, 29);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new Point(468, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new Size(94, 29);
            this.btnNew.TabIndex = 12;
            this.btnNew.Text = "Yeni";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new EventHandler(this.btnNew_Click);
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 400);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.panelForm);
            this.Name = "InventoryForm";
            this.Text = "Stok Yönetimi";
            this.Load += new EventHandler(this.InventoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
        }

        private DataGridView dgvInventory;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colProduct;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colProcess;
        private DataGridViewTextBoxColumn colWarehouse;
        private DataGridViewTextBoxColumn colDate;
        private Panel panelForm;
        private Label lblTitle;
        private Label lblProduct;
        private ComboBox cmbProduct;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private Label lblProcess;
        private ComboBox cmbProcess;
        private Label lblWarehouse;
        private TextBox txtWarehouse;
        private Button btnSave;
        private Button btnCancel;
        private Button btnDelete;
        private Button btnNew;

        private async void LoadData()
        {
            try
            {
                // Load products
                _products = await _productService.GetAllProductsAsync();
                cmbProduct.DataSource = null;
                cmbProduct.DisplayMember = "Name";
                cmbProduct.ValueMember = "Id";
                cmbProduct.DataSource = _products;

                // Setup process dropdown
                cmbProcess.DataSource = Enum.GetValues(typeof(InvertoryProcess));

                // Load inventories
                _inventories = await _inventoryService.GetAllInventoriesAsync();

                // Add ProcessText property for display
                foreach (var inventory in _inventories)
                {
                    inventory.ProcessText = inventory.Process.ToString();
                }

                dgvInventory.DataSource = null;
                dgvInventory.DataSource = _inventories;

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            if (cmbProduct.Items.Count > 0)
                cmbProduct.SelectedIndex = 0;

            numQuantity.Value = 1;
            cmbProcess.SelectedIndex = 0;
            txtWarehouse.Text = "Ana Depo";

            _selectedInventoryId = null;
            btnDelete.Enabled = false;
        }

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var inventory = _inventories[e.RowIndex];
                _selectedInventoryId = inventory.Id;

                // Find and select the product
                for (int i = 0; i < cmbProduct.Items.Count; i++)
                {
                    var product = (ProductDto)cmbProduct.Items[i];
                    if (product.Id == inventory.ProductId)
                    {
                        cmbProduct.SelectedIndex = i;
                        break;
                    }
                }

                numQuantity.Value = inventory.Quantity;
                cmbProcess.SelectedItem = inventory.Process;
                txtWarehouse.Text = inventory.WarehouseName;

                btnDelete.Enabled = true;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir ürün seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtWarehouse.Text))
            {
                MessageBox.Show("Lütfen depo adını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var inventory = new InventoryDto
                {
                    ProductId = ((ProductDto)cmbProduct.SelectedItem).Id,
                    Quantity = (int)numQuantity.Value,
                    Process = (InvertoryProcess)cmbProcess.SelectedItem,
                    WarehouseName = txtWarehouse.Text
                };

                if (_selectedInventoryId.HasValue)
                {
                    // Update existing inventory
                    inventory.Id = _selectedInventoryId.Value;
                    var result = await _inventoryService.UpdateInventoryAsync(inventory);

                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Stok hareketi başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show($"Stok hareketi güncellenirken hata oluştu: {result.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Create new inventory
                    var result = await _inventoryService.CreateInventoryAsync(inventory);

                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Stok hareketi başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show($"Stok hareketi eklenirken hata oluştu: {result.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (!_selectedInventoryId.HasValue) return;

            if (MessageBox.Show("Seçili stok hareketini silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var result = await _inventoryService.DeleteInventoryAsync(_selectedInventoryId.Value);

                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Stok hareketi başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show($"Stok hareketi silinirken hata oluştu: {result.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"İşlem sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}