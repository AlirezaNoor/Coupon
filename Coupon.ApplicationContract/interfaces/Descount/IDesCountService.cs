using Coupon.ApplicationContract.Dto.DisCount;
using Coupon.ApplicationContract.Dto.DisCount.AddCategoryToDesCount;
using Microsoft.AspNetCore.Http;

namespace Coupon.ApplicationContract.interfaces.Descount;

public interface IDesCountService
{
    Task CreateDiscountAsync(CreateDescount dto);
    Task<IEnumerable<DescountDTO>> GetAllDiscountsAsync();
    Task<DescountDTO> GetDiscountByIdAsync(long id);
    Task UpdateDiscountAsync(long id, CreateDescount dto);
    Task DeleteDiscountAsync(long id);
    Task<List<long>> GetAllCategoryforDiscount(long Id);
 }