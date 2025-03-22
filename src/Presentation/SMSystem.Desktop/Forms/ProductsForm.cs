using SMSystem.Desktop.Models;
using SMSystem.Desktop.Services.Interfaces;
using SMSystem.Domain.Dtos;
using System.Drawing;
using System.IO;

namespace SMSystem.Desktop.Forms
{
    public partial class ProductsForm : BaseForm
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private List<ProductDto> _products = new List<ProductDto>();
        private List<CategoryDto> _categories = new List<CategoryDto>();
        private int? _selectedProductId = null;
        private string _selectedImagePath = null;

        public ProductsForm(IProductService productService, ICategoryService categoryService)
        {
            InitializeComponent();
            _productService = productService;
            _categoryService = categoryService;
        }

        private void BtnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Ürün Resmi Seç";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _selectedImagePath = openFileDialog.FileName;
                    try
                    {
                        pictureBoxImage.Image = Image.FromFile(_selectedImagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBoxShow.Error($"Resim yüklenirken hata oluştu: {ex.Message}");
                        _selectedImagePath = null;
                    }
                }
            }
        }



        private async void LoadData()
        {
            try
            {
                _categories = await _categoryService.GetAllCategoriesAsync();
                cmbCategory.DataSource = null;
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "Id";
                cmbCategory.DataSource = _categories;

                _products = await _productService.GetAllProductsAsync();
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = _products;

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBoxShow.Error($"Veri yüklenirken hata oluştu: {ex.Message}");
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
            _selectedImagePath = null;
            btnDelete.Enabled = false;

            if (pictureBoxImage != null)
            {
                pictureBoxImage.Image = null;
                pictureBoxImage.Invalidate();
            }
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
                _selectedImagePath = null; 

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

                if (pictureBoxImage != null && !string.IsNullOrEmpty(product.Image))
                {
                    try
                    {
                        using (HttpClient httpClient = new HttpClient())
                        {
                            string imageUrl = $"{Api.BaseUrl}/{product.Image}";
                            byte[] imageBytes = httpClient.GetByteArrayAsync(imageUrl).GetAwaiter().GetResult();
                            using (MemoryStream memoryStream = new MemoryStream(imageBytes))
                            {
                                pictureBoxImage.Image = new Bitmap(memoryStream);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBoxShow.Error($"Resim yüklenirken hata oluştu: {ex.Message}");
                    }
                }
                else if (pictureBoxImage != null)
                {
                    pictureBoxImage.Image = null;
                }
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
                MessageBoxShow.Warning("Lütfen ürün adını giriniz.");
                return;
            }

            if (cmbCategory.SelectedItem == null)
            {
                MessageBoxShow.Warning("Lütfen bir kategori seçiniz.");
                return;
            }

            if (_selectedImagePath == null && !_selectedProductId.HasValue)
            {
                MessageBoxShow.Warning("Lütfen bir resim seçiniz.");
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
                    product.Id = _selectedProductId.Value;

                    var existingProduct = _products.FirstOrDefault(p => p.Id == _selectedProductId.Value);
                    if (existingProduct != null)
                    {
                        product.Image = existingProduct.Image;
                    }

                    var result = await _productService.UpdateProductAsync(product, _selectedImagePath);

                    if (result.IsSuccess)
                    {
                        MessageBoxShow.Info("Ürün başarıyla güncellendi.");
                        LoadData();
                    }
                    else
                    {
                        MessageBoxShow.Error($"Ürün güncellenirken hata oluştu: {result.Message}");
                    }
                }
                else
                {
                    var result = await _productService.CreateProductAsync(product, _selectedImagePath);

                    if (result.IsSuccess)
                    {
                        MessageBoxShow.Info("Ürün başarıyla eklendi.");
                        LoadData();
                    }
                    else
                    {
                        MessageBoxShow.Error($"Ürün eklenirken hata oluştu: {result.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxShow.Error($"Ürün eklenirken hata oluştu: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_selectedProductId.HasValue) return;

            if (MessageBoxShow.Confirm("Seçili ürünü silmek istediğinize emin misiniz?"))
            {
                try
                {
                    var result = await _productService.DeleteProductAsync(_selectedProductId.Value);

                    if (result.IsSuccess)
                    {
                        MessageBoxShow.Info("Ürün başarıyla silindi.");
                        LoadData();
                    }
                    else
                    {
                        MessageBoxShow.Error($"Ürün silinirken hata oluştu: {result.Message}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxShow.Error($"İşlem sırasında hata oluştu: {ex.Message}");
                }
            }
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}