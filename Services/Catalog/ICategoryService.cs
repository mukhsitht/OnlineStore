using Data.Catalog;

namespace Services.Catalog
{
    public interface ICategoryService
    {
        Task<List<VWCategory>> GetAll();
        Task<Category?> GetById(int id);
        Task Add(Category category);
        Task Update(Category category);
        Task Delete(Category category);
    }
}
