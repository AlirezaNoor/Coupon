using Coupon.Domain.Entities.Descount;
using Coupon.Domain.Repositories.Generic;

namespace Coupon.Domain.Repositories.Descount;

public interface IAddCategoryToDescountRepository:IGenericRepository<AddCategoryToDiscount>
{
    Task<bool> CreateWithcheck(AddCategoryToDiscount discounts);
 }