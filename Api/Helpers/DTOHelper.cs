using Api.Dto.Catalog;
using AutoMapper;
using Data.Catalog;

namespace Api.Helpers
{
    public class DTOHelper
    {
        private readonly IMapper _mapper;
        public DTOHelper(IMapper mapper)
        {
            _mapper = mapper;
        }
        public ProductDto PrepareProductDto(VWProduct product)
        {
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }
        public ItemDetailDto PrepareItemDetailDto(ItemDetail itemDetail)
        {
            var itemDetailDto = _mapper.Map<ItemDetailDto>(itemDetail);
            return itemDetailDto;
        }
    }
}
