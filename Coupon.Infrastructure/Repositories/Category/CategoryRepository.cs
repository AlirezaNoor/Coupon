using Coupon.Domain.Repositories.Categories;
using Coupon.Infrastructure.Context;
using Coupon.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Coupon.Infrastructure.Repositories.Category;

public class CategoryRepository:GenericRepository<Domain.Entities.Categories.Category>,ICategoryRepository
{
    private readonly DbCoupon _context;

    public CategoryRepository(DbCoupon context) : base(context)
    {
        _context = context;
    }

    public async Task<IQueryable<Domain.Entities.Categories.Category>> GetAllQuery()
    {
        var categories =  _context.Categories.AsQueryable();
        return categories;
    }
}