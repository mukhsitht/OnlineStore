using Api.Dto.Catalog;
using AutoMapper;
using Data.Catalog;

namespace Api.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>(MemberList.None).ReverseMap();
            CreateMap<VWProduct, ProductDto>(MemberList.None).ReverseMap();
            CreateMap<ItemDetail, ItemDetailDto>(MemberList.None).ReverseMap();
        }
    }
}
