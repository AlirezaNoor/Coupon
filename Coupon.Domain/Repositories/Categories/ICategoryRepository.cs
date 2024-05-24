using Coupon.Domain.Entities.Categories;
using Coupon.Domain.Repositories.Generic;

namespace Coupon.Domain.Repositories.Categories;

public interface ICategoryRepository:IGenericRepository<Category>
{
    Task<IQueryable<Category>> GetAllQuery();
}