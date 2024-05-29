using Coupon.ApplicationContract.Dto.Categories;
using Coupon.ApplicationContract.Dto.DisCount;
using Coupon.ApplicationContract.Dto.Store;
using Coupon.Domain.Entities.Categories;
using Coupon.Domain.Entities.Descount;
using Coupon.Domain.Entities.Stores;

namespace Coupon.ApplicationContract.Profile;

public class AutoProfile:AutoMapper.Profile
{
    public AutoProfile()
    {
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Store, CreateStore>().ReverseMap();
        CreateMap<Store, UpdateStore>().ReverseMap();
        CreateMap<Store, StoreDto>().ReverseMap();
        CreateMap<Discounts, CreateDescount>().ReverseMap();
        CreateMap<Discounts, UpdateDesCount>().ReverseMap();
        CreateMap<Discounts, DescountDTO>().ReverseMap();
   
    }
}