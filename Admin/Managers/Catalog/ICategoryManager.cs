using Admin.Models.Catalog;

namespace Admin.Managers.Catalog
{
    public interface ICategoryManager
    {
        Task<List<CategoryModel>> GetAllCategories();
        Task<bool> Add(CategoryModel categoryModel);
    }
}
