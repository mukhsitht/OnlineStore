using Data.Catalog;
using Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Services.Catalog
{
    public class CategoryService : ICategoryService
    {
        private readonly OnlineStoreDbContext _context;
        public CategoryService(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public async Task<List<VWCategory>> GetAll()
        {
            var categories = _context.VWCategories.AsNoTracking().AsQueryable();
            return await categories.ToListAsync();
        }
        public async Task<Category?> GetById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
        public async Task Add(Category category)
        {
            category.CreatedOn = DateTime.Now;
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
