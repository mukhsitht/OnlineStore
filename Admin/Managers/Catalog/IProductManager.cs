using Admin.Models.Catalog;

namespace Admin.Managers.Catalog
{
    public interface IProductManager
    {
        Task<List<ProductModel>> GetAllProducts(int? year, int? month, int? day);
        Task<ProductModel> GetProduct(int id);
        Task<bool> Add(ProductModel productModel);
        Task<bool> Edit(ProductModel productModel);
        Task<bool> Delete(int id);
    }
}
