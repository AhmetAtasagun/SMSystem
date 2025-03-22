using SMSystem.Desktop.Models;
using SMSystem.Desktop.Services.Interfaces;
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
        }

        private async void LoadData()
        {
            try
            {
                _categories = await _categoryService.GetAllCategoriesAsync();

                var parentCategories = new List<CategoryDto>(_categories);
                parentCategories.Insert(0, new CategoryDto { Id = 0, Name = "-- Ana Kategori --" });

                cmbParent.DataSource = null;
                cmbParent.DisplayMember = "Name";
                cmbParent.ValueMember = "Id";
                cmbParent.DataSource = parentCategories;

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

                dgvCategories.DataSource = null;
                dgvCategories.DataSource = _categories;

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
                    cmbParent.SelectedIndex = 0; 
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
                MessageBoxShow.Warning("Lütfen kategori adını giriniz.");
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
                    category.Id = _selectedCategoryId.Value;

                    if (category.ParentId.HasValue && (category.ParentId.Value == category.Id || IsChildCategory(category.Id, category.ParentId.Value)))
                    {
                        MessageBoxShow.Warning("Bir kategori kendisini veya alt kategorisini üst kategori olarak seçemez.");
                        return;
                    }

                    var result = await _categoryService.UpdateCategoryAsync(category);

                    if (result.IsSuccess)
                    {
                        MessageBoxShow.Info("Kategori başarıyla güncellendi.");
                        LoadData();
                    }
                    else
                    {
                        MessageBoxShow.Error($"Kategori güncellenirken hata oluştu: {result.Message}");
                    }
                }
                else
                {
                    var result = await _categoryService.CreateCategoryAsync(category);

                    if (result.IsSuccess)
                    {
                        MessageBoxShow.Info("Kategori başarıyla eklendi.");
                        LoadData();
                    }
                    else
                    {
                        MessageBoxShow.Error($"Kategori eklenirken hata oluştu: {result.Message}");
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
            if (!_selectedCategoryId.HasValue) return;

            if (MessageBoxShow.Confirm("Seçili kategoriyi silmek istediğinize emin misiniz?"))
            {
                try
                {
                    var result = await _categoryService.DeleteCategoryAsync(_selectedCategoryId.Value);

                    if (result.IsSuccess)
                    {
                        MessageBoxShow.Info("Kategori başarıyla silindi.");
                        LoadData();
                    }
                    else
                    {
                        MessageBoxShow.Error($"Kategori silinirken hata oluştu: {result.Message}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxShow.Error($"İşlem sırasında hata oluştu: {ex.Message}");
                }
            }
        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private bool IsChildCategory(int parentId, int childId)
        {
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