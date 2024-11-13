using Admin.Helpers;
using Admin.Models.Catalog;
using AutoMapper;
using Data.Catalog;
using Services.Catalog;
using Utilities.Common;
using Utilities.Model;

namespace Admin.Managers.Catalog
{
    public class ProductManager : IProductManager
    {
        private readonly ILogger<ProductManager> _logger;
        private readonly IMapper _mapper;
        private readonly AppSettingsModel _appSettings;
        private readonly ImageHelper _imageHelper;
        private readonly ModelHelper _modelHelper;
        private readonly IProductService _productService;
        public ProductManager(ILogger<ProductManager> logger,
            IMapper mapper,
            AppSettingsModel options,
            ImageHelper imageHelper,
            ModelHelper modelHelper,
            IProductService productService)
        {
            _logger = logger;
            _mapper = mapper;
            _appSettings = options;
            _imageHelper = imageHelper;
            _modelHelper = modelHelper;
            _productService = productService;
        }
        public async Task<List<ProductModel>> GetAllProducts(int? year, int? month, int? day)
        {
            var productModels = new List<ProductModel>();
            try
            {
                var products = await _productService.GetAll(year, month, day);
                if (products != null)
                {
                    productModels = products.Select(product =>
                    {
                        return _modelHelper.PrepareProductModel(product);
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return productModels;
        }
        public async Task<ProductModel> GetProduct(int id)
        {
            var productModel = new ProductModel();
            try
            {
                var product = await _productService.GetVWProductById(id);
                if (product != null)
                {
                    productModel = _modelHelper.PrepareProductModel(product); ;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return productModel;
        }
        public async Task<bool> Add(ProductModel productModel)
        {
            try
            {
                if (productModel.CategoryId == null || productModel.Price == null)
                {
                    return false;
                }

                var product = new Product
                {
                    CategoryId = productModel.CategoryId.Value,
                    Name = productModel.Name,
                    Description = productModel.Description,
                    Price = productModel.Price.Value
                };

                if (productModel.File != null)
                {
                    string fileName = await _imageHelper.SaveImageAsync(productModel.File, _appSettings?.ImageSettings?.Products);
                    if (string.IsNullOrEmpty(fileName))
                    {
                        return false;
                    }

                    product.Photo = fileName;
                }

                await _productService.Add(product);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return false;
        }
        public async Task<bool> Edit(ProductModel productModel)
        {
            try
            {
                if (productModel.CategoryId == null || productModel.Price == null)
                {
                    return false;
                }

                var product = await _productService.GetById(productModel.Id);
                if (product == null)
                {
                    return false;
                }

                product.CategoryId = productModel.CategoryId.Value;
                product.Name = productModel.Name;
                product.Description = productModel.Description;
                product.Price = productModel.Price.Value;

                if (productModel.File != null)
                {
                    string fileName = await _imageHelper.SaveImageAsync(productModel.File, _appSettings?.ImageSettings?.Products);
                    if (string.IsNullOrEmpty(fileName))
                    {
                        return false;
                    }

                    product.Photo = fileName;
                }

                await _productService.Update(product);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return false;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var product = await _productService.GetById(id);
                if (product == null)
                {
                    return false;
                }

                await _productService.Delete(product);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return false;
        }
    }
}
