using Admin.Helpers;
using Admin.Models.Catalog;
using AutoMapper;
using Azure;
using Data.Catalog;
using Services.Catalog;

namespace Admin.Managers.Catalog
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ILogger<CategoryManager> _logger;
        private readonly IMapper _mapper;
        private readonly ModelHelper _modelHelper;
        private readonly ICategoryService _categoryService;
        public CategoryManager(ILogger<CategoryManager> logger,
            IMapper mapper,
            ModelHelper modelHelper,
        ICategoryService categoryService)
        {
            _logger = logger;
            _mapper = mapper;
            _modelHelper = modelHelper;
            _categoryService = categoryService;
        }
        public async Task<List<CategoryModel>> GetAllCategories()
        {
            var categoryModels = new List<CategoryModel>();
            try
            {
                var categories = await _categoryService.GetAll();
                if (categories != null)
                {
                    categoryModels = categories.Select(category =>
                    {
                        return _modelHelper.PrepareCategoryModel(category);
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return categoryModels;
        }
        public async Task<bool> Add(CategoryModel categoryModel)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryModel);
                await _categoryService.Add(category);

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
