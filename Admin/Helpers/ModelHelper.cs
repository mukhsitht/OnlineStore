using Admin.Models.Catalog;
using AutoMapper;
using Data.Catalog;
using Utilities.Model;

namespace Admin.Helpers
{
    public class ModelHelper
    {
        private readonly ILogger<ModelHelper> _logger;
        private readonly IMapper _mapper;
        private readonly AppSettingsModel _appSettings;
        public ModelHelper(ILogger<ModelHelper> logger,
            IMapper mapper,
            AppSettingsModel appSettings)
        {
            _logger = logger;
            _mapper = mapper;
            _appSettings = appSettings;
        }
        public CategoryModel PrepareCategoryModel(VWCategory category)
        {
            var categoryModel = _mapper.Map<CategoryModel>(category);
            return categoryModel;
        }
        public ProductModel PrepareProductModel(VWProduct product)
        {
            var productModel = _mapper.Map<ProductModel>(product);
            productModel.PhotoUrl = _appSettings?.CommonSettings?.APIBaseUrl + _appSettings?.ImageSettings?.Products + product?.Photo;
            return productModel;
        }
    }
}
