using Coupon.ApplicationContract.Dto.Categories;

namespace Coupon.ApplicationContract.interfaces.Category;

public interface ICategoriesService
{
    Task CreateCategory(CreateCategoryDto categoryDto);
    Task UpdateCategory(UpdateCategoryDto categoryDto);
    Task Delete(long Id);
    Task<CategoryDto> GetbyId(long Id);
    Task<IQueryable<CategoryDto>> GetAll();
  
}