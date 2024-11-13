using Data.Catalog;
using Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Services.Catalog
{
    public class ProductService : IProductService
    {
        private readonly OnlineStoreDbContext _context;
        public ProductService(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public async Task<List<VWProduct>> GetAll(int? year = null, int? month = null, int? day = null, bool orderByRandom = false)
        {
            var products = _context.VWProducts.AsNoTracking().AsQueryable();

            if (year != null)
            {
                products = products.Where(x => x.CreatedOn.Date.Year == year.Value);
            }

            if (month != null)
            {
                products = products.Where(x => x.CreatedOn.Date.Month == month.Value);
            }

            if (day != null)
            {
                products = products.Where(x => x.CreatedOn.Date.Day == day.Value);
            }

            if (orderByRandom)
            {
                products = products.OrderByDescending(x => Guid.NewGuid());
            }
            else
            {
                products = products.OrderByDescending(x => x.Id);
            }

            return await products.ToListAsync();
        }
        public async Task<VWProduct?> GetVWProductById(int id)
        {
            return await _context.VWProducts.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Product?> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        public async Task<ItemDetail?> GetItemDetails(int id)
        {
            return await _context.GetItemDetails(id);
        }
        public async Task Add(Product product)
        {
            product.CreatedOn = DateTime.Now;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
