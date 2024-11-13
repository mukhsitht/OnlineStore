using Admin.Helpers;
using Admin.Managers.Catalog;
using Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Services.Catalog;
using System.IdentityModel.Tokens.Jwt;
using Utilities.Common;

namespace Admin.Infrastructure
{
    public static class CommonExtension
    {
        public static void AddDbContext(this WebApplicationBuilder builder)
        {
            // Add DbContext with SQL provider
            builder.Services.AddDbContext<OnlineStoreDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        }
        public static void AddAutoMapper(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(Program));
        }
        public static void RegisterService(this WebApplicationBuilder builder)
        {
            #region Services
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            #endregion

            #region Managers
            builder.Services.AddScoped<ICategoryManager, CategoryManager>();
            builder.Services.AddScoped<IProductManager, ProductManager>();
            #endregion

            #region Model Helpers
            builder.Services.AddScoped<ModelHelper>();
            #endregion

            #region Utility Helpers
            builder.Services.AddScoped<ImageHelper>();
            #endregion
        }
    }
}
