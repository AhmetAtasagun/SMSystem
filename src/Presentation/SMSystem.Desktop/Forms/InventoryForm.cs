using SMSystem.Desktop.Models;
using SMSystem.Desktop.Services.Interfaces;
using SMSystem.Domain.Dtos;
using SMSystem.Domain.Enums;

namespace SMSystem.Desktop.Forms
{
    public partial class InventoryForm : BaseForm
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
        }

        private async void LoadData()
        {
            try
            {
                _products = await _productService.GetAllProductsAsync();
                cmbProduct.DataSource = null;
                cmbProduct.DisplayMember = "Name";
                cmbProduct.ValueMember = "Id";
                cmbProduct.DataSource = _products;

                cmbProcess.DataSource = Enum.GetValues(typeof(InvertoryProcess));

                _inventories = await _inventoryService.GetAllInventoriesAsync();

                dgvInventory.DataSource = null;
                dgvInventory.DataSource = _inventories;

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBoxShow.Error($"Veri yüklenirken hata oluştu: {ex.Message}");
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
                MessageBoxShow.Warning("Lütfen bir ürün seçiniz.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtWarehouse.Text))
            {
                MessageBoxShow.Warning("Lütfen depo adını giriniz.");
                return;
            }

            try
            {
                var inventory = new InventoryDto
                {
                    ProductId = ((ProductDto)cmbProduct.SelectedItem).Id,
                    Quantity = (int)numQuantity.Value,
                    Process = cmbProcess.SelectedItem.ToString(),
                    WarehouseName = txtWarehouse.Text
                };

                if (_selectedInventoryId.HasValue)
                {
                    inventory.Id = _selectedInventoryId.Value;
                    var result = await _inventoryService.UpdateInventoryAsync(inventory);

                    if (result.IsSuccess)
                    {
                        MessageBoxShow.Info("Stok hareketi başarıyla güncellendi.");
                        LoadData();
                    }
                    else
                    {
                        MessageBoxShow.Error($"Stok hareketi güncellenirken hata oluştu: {result.Message}");
                    }
                }
                else
                {
                    var result = await _inventoryService.CreateInventoryAsync(inventory);

                    if (result.IsSuccess)
                    {
                        MessageBoxShow.Info("Stok hareketi başarıyla eklendi.");
                        LoadData();
                    }
                    else
                    {
                        MessageBoxShow.Error($"Stok hareketi eklenirken hata oluştu: {result.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxShow.Error($"İşlem sırasında hata oluştu: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_selectedInventoryId.HasValue) return;

            if (MessageBoxShow.Confirm("Seçili stok hareketini silmek istediğinize emin misiniz?"))
            {
                try
                {
                    var result = await _inventoryService.DeleteInventoryAsync(_selectedInventoryId.Value);

                    if (result.IsSuccess)
                    {
                        MessageBoxShow.Info("Stok hareketi başarıyla silindi.");
                        LoadData();
                    }
                    else
                    {
                        MessageBoxShow.Error($"Stok hareketi silinirken hata oluştu: {result.Message}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxShow.Error($"İşlem sırasında hata oluştu: {ex.Message}");
                }
            }
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}