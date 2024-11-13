using Api.Dto.Catalog;
using Api.Helpers;
using AutoMapper;
using Data.Catalog;
using Services.Catalog;
using Utilities.Model;

namespace Api.Managers.Catalog
{
    public class ProductManager : IProductManager
    {
        private readonly ILogger<ProductManager> _logger;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly DTOHelper _dtoHelper;
        public ProductManager(ILogger<ProductManager> logger,
            IMapper mapper,
            IProductService productService,
            DTOHelper dtoHelper)
        {
            _logger = logger;
            _mapper = mapper;
            _productService = productService;
            _dtoHelper = dtoHelper;
        }
        public async Task<ApiResponseModel<List<ProductDto>>> GetProductsListRandomOrder()
        {
            var response = new ApiResponseModel<List<ProductDto>>();

            try
            {
                var products = await _productService.GetAll(orderByRandom: true);

                var productDtos = products.Select(product =>
                {
                    return _dtoHelper.PrepareProductDto(product);
                }).ToList();

                response.Data = productDtos;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Message = "An error occured. Please try again. If the problem persists, contact the site administrator.";
            }

            return response;
        }
        public async Task<ApiResponseModel<ProductDto>> GetProductDetailsById(int id)
        {
            var response = new ApiResponseModel<ProductDto>();

            try
            {
                var product = await _productService.GetVWProductById(id);

                if (product != null)
                {
                    response.Data = _dtoHelper.PrepareProductDto(product);
                }

                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Message = "An error occured. Please try again. If the problem persists, contact the site administrator.";
            }

            return response;
        }
        public async Task<ApiResponseModel<ItemDetailDto>> GetProductDetailsByIdWithCurrency(int id)
        {
            var response = new ApiResponseModel<ItemDetailDto>();

            try
            {
                var itemDetail = await _productService.GetItemDetails(id);

                if (itemDetail != null)
                {
                    response.Data = _dtoHelper.PrepareItemDetailDto(itemDetail);
                }

                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Message = "An error occured. Please try again. If the problem persists, contact the site administrator.";
            }

            return response;
        }
    }
}
