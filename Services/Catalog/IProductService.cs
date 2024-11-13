using Data.Catalog;

namespace Services.Catalog
{
    public interface IProductService
    {
        Task<List<VWProduct>> GetAll(int? year = null, int? month = null, int? day = null, bool orderByRandom = false);
        Task<VWProduct?> GetVWProductById(int id);
        Task<Product?> GetById(int id);
        Task<ItemDetail?> GetItemDetails(int id);
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(Product product);
    }
}
