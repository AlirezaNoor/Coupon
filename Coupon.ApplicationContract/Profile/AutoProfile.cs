using Coupon.ApplicationContract.Dto.Categories;
using Coupon.Domain.Entities.Categories;

namespace Coupon.ApplicationContract.Profile;

public class AutoProfile:AutoMapper.Profile
{
    public AutoProfile()
    {
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}