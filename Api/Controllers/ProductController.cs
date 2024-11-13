using Api.Dto.Catalog;
using Api.Managers.Catalog;
using Microsoft.AspNetCore.Mvc;
using Utilities.Model;

namespace Api.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet, Route("/Product/GetProductsListRandomOrder")]
        public async Task<ApiResponseModel<List<ProductDto>>> GetHomePageContent()
        {
            return await _productManager.GetProductsListRandomOrder();
        }

        [HttpGet, Route("/Product/GetProductDetailsById")]
        public async Task<ApiResponseModel<ProductDto>> GetProductDetailsById(int id)
        {
            return await _productManager.GetProductDetailsById(id);
        }

        [HttpGet, Route("/Product/GetProductDetailsByIdWithCurrency")]
        public async Task<ApiResponseModel<ItemDetailDto>> GetProductDetailsByIdWithCurrency(int id)
        {
            return await _productManager.GetProductDetailsByIdWithCurrency(id);
        }
    }
}
