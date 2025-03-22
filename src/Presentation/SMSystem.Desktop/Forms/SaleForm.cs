using SMSystem.Desktop.Models;
using SMSystem.Desktop.Services.Interfaces;
using SMSystem.Domain.Dtos;
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
    public partial class SaleForm : BaseForm
    {
        private readonly IProductService _productService;
        private readonly ISaleService _saleService;
        private readonly IAuthService _authService;
        
        private List<ProductDto> _products = new List<ProductDto>();
        private List<SaleDto> _sales = new List<SaleDto>();
        private int? _selectedSaleId = null;
        private bool _isEditMode = false;

        public SaleForm(IProductService productService, ISaleService saleService, IAuthService authService)
        {
            InitializeComponent();
            _productService = productService;
            _saleService = saleService;
            _authService = authService;            
        }

        private void SaleForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadSales();
            SetFormState(false);
        }

        private async void LoadProducts()
        {
            try
            {
                _products = await _productService.GetAllProductsAsync();
                
                comboBoxProducts.DataSource = null;
                comboBoxProducts.DisplayMember = "Name";
                comboBoxProducts.ValueMember = "Id";
                comboBoxProducts.DataSource = _products;
            }
            catch (Exception ex)
            {
                MessageBoxShow.Error($"Ürünler yüklenirken hata oluştu: {ex.Message}");
            }
        }

        private async void LoadSales()
        {
            try
            {
                _sales = await _saleService.GetAllAsync();
                
                dataGridViewSales.DataSource = null;
                dataGridViewSales.DataSource = _sales;
                
                // Configure columns
                if (dataGridViewSales.Columns.Count > 0)
                {
                    dataGridViewSales.Columns["Id"].HeaderText = "ID";
                    dataGridViewSales.Columns["ProductName"].HeaderText = "Ürün Adı";
                    dataGridViewSales.Columns["Price"].HeaderText = "Satış Fiyatı";
                    dataGridViewSales.Columns["ProductPrice"].HeaderText = "Ürün Fiyatı";
                    dataGridViewSales.Columns["Quantity"].HeaderText = "Miktar";
                    dataGridViewSales.Columns["StaffName"].HeaderText = "Personel";
                }
            }
            catch (Exception ex)
            {
                MessageBoxShow.Error($"Satışlar yüklenirken hata oluştu: {ex.Message}");
            }
        }

        private void SetFormState(bool isEdit)
        {
            _isEditMode = isEdit;
            btnSave.Text = isEdit ? "Güncelle" : "Kaydet";
            groupBoxSaleDetails.Text = isEdit ? "Satış Düzenle" : "Yeni Satış";
        }

        private void ClearForm()
        {
            _selectedSaleId = null;
            comboBoxProducts.SelectedIndex = -1;
            numericPrice.Value = 0;
            numericQuantity.Value = 1;
            SetFormState(false);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (comboBoxProducts.SelectedIndex == -1)
            {
                MessageBoxShow.Warning("Lütfen bir ürün seçin.");
                return;
            }

            int productId = (int)comboBoxProducts.SelectedValue;
            decimal price = numericPrice.Value;
            int quantity = (int)numericQuantity.Value;

            bool success;
            if (_isEditMode && _selectedSaleId.HasValue)
            {
                success = await _saleService.UpdateAsync(_selectedSaleId.Value, productId, price, quantity);
            }
            else
            {
                success = await _saleService.CreateAsync(productId, price, quantity);
            }

            if (success)
            {
                ClearForm();
                LoadSales();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnListSales_Click(object sender, EventArgs e)
        {
            LoadSales();
        }

        private void btnNewSale_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewSales.SelectedRows.Count > 0)
            {
                int saleId = (int)dataGridViewSales.SelectedRows[0].Cells["Id"].Value;
                await LoadSaleForEdit(saleId);
            }
            else
            {
                MessageBoxShow.Warning("Lütfen düzenlemek için bir satış seçin.");
            }
        }

        private async void dataGridViewSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int saleId = (int)dataGridViewSales.Rows[e.RowIndex].Cells["Id"].Value;
                await LoadSaleForEdit(saleId);
            }
        }

        private async Task LoadSaleForEdit(int saleId)
        {
            try
            {
                var sale = await _saleService.GetByIdAsync(saleId);
                if (sale != null)
                {
                    _selectedSaleId = sale.Id;
                    
                    // Find the product in the combobox
                    var productIndex = _products.FindIndex(p => p.Name == sale.ProductName);
                    if (productIndex >= 0)
                    {
                        comboBoxProducts.SelectedIndex = productIndex;
                    }
                    
                    numericPrice.Value = sale.Price;
                    numericQuantity.Value = sale.Quantity;
                    
                    SetFormState(true);
                }
            }
            catch (Exception ex)
            {
                MessageBoxShow.Error($"Satış bilgileri yüklenirken hata oluştu: {ex.Message}");
            }
        }

        private void comboBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProducts.SelectedIndex >= 0 && !_isEditMode)
            {
                var selectedProduct = (ProductDto)comboBoxProducts.SelectedItem;
                numericPrice.Value = selectedProduct.Price;
            }
        }
    }
}
