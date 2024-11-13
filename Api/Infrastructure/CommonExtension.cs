using Api.Helpers;
using Api.Managers.Catalog;
using Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Services.Catalog;
using Utilities.Common;
using Utilities.Model;

namespace Api.Infrastructure
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
            builder.Services.AddScoped<IProductManager, ProductManager>();
            #endregion

            #region Model Helpers
            builder.Services.AddScoped<DTOHelper>();
            #endregion

            #region Utility Helpers
            builder.Services.AddScoped<ImageHelper>();
            #endregion
        }
        public static void AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Online Store", Version = "v1" });
            });
        }
        public static void AddCors(this WebApplicationBuilder builder, AppSettingsModel appSettingsModel)
        {
            var myAllowSpecificOrigins = appSettingsModel.CommonSettings?.CorsPolicyName ?? string.Empty;
            string CorsAllowedUrls = appSettingsModel.CommonSettings?.CorsAllowedUrls ?? string.Empty;

            builder.Services.AddCors(
             options => options.AddPolicy(
                 myAllowSpecificOrigins,
                 builder => builder
                     .WithOrigins(CorsAllowedUrls.Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray())
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .AllowCredentials()
                     .SetPreflightMaxAge(TimeSpan.FromSeconds(3600)))
            );
        }
    }
}
