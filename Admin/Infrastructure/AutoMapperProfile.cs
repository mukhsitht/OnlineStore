using Admin.Models.Catalog;
using AutoMapper;
using Data.Catalog;

namespace Admin.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryModel>(MemberList.None).ReverseMap();
            CreateMap<Product, ProductModel>(MemberList.None).ReverseMap();
            CreateMap<VWCategory, CategoryModel>(MemberList.None).ReverseMap();
            CreateMap<VWProduct, ProductModel>(MemberList.None).ReverseMap();
        }
    }
}
