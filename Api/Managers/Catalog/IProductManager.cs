using Api.Dto.Catalog;
using Utilities.Model;

namespace Api.Managers.Catalog
{
    public interface IProductManager
    {
        Task<ApiResponseModel<List<ProductDto>>> GetProductsListRandomOrder();
        Task<ApiResponseModel<ProductDto>> GetProductDetailsById(int id);
        Task<ApiResponseModel<ItemDetailDto>> GetProductDetailsByIdWithCurrency(int id);
    }
}
