using AutoMapper;
using Restaurant.BLL.Models;
using Restaurant.DAL.Entities;

namespace Restaurant.PL.Models
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CategoryDto, CategoryViewModel>()
                .ForMember(cv => cv.Id , c => c.MapFrom(c => c.Id))
                .ForMember(cv => cv.Name , c => c.MapFrom(c => c.Name))
                .ReverseMap();
            CreateMap<CategoryDto, CategoryCreateModel>()
               .ReverseMap();

            CreateMap<IngredientDto, IngredientViewModel>()
               .ForMember(ivm => ivm.Id, id => id.MapFrom(id => id.Id))
               .ForMember(ivm => ivm.Name, id => id.MapFrom(id => id.Name))
               .ReverseMap();

            CreateMap<ProductDto, ProductViewModel>().ReverseMap();

            CreateMap<OrderDto, OrderViewModel>().ReverseMap();

            CreateMap<ProductDto, ProductDetailModel>()
                .ForMember(pd => pd.Id, p => p.MapFrom(p => p.Id))
                .ForMember(pd => pd.Name, p => p.MapFrom(pd => pd.Name))
                .ForMember(pd => pd.Cost, p => p.MapFrom(pd => pd.Cost))
                .ForMember(pd => pd.Weight, p => p.MapFrom(pd => pd.Weight))
                .ReverseMap();

            CreateMap<CategoryDto, CategoryDetail>()
                .ForMember(cd => cd.Id, c => c.MapFrom(c => c.Id))
                .ForMember(cd => cd.Name, c => c.MapFrom(c => c.Name))
                .ReverseMap();

            CreateMap<IngredientCreateModel, IngredientDto>().ReverseMap();

            CreateMap<OrderDetailDto, OrderDetailCreateModel>().ReverseMap();

            CreateMap<OrderCreateModel, OrderDto>().ReverseMap();

            CreateMap<OrderDetailDto, OrderDetailViewModel>().ReverseMap();

            CreateMap<OrderDto, OrderDetailModel>().ReverseMap();

            CreateMap<User, UserCreateModel>().ReverseMap();

            CreateMap<ProductCreateModel, ProductDto>().ReverseMap();

            CreateMap<User, UserUpdateModel>().ReverseMap();

            CreateMap<User, UserViewModel>().ReverseMap();


        }
    }
}
