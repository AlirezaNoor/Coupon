using Coupon.Domain.Entities.Descount;
using Coupon.Domain.Repositories.Descount;
using Coupon.Infrastructure.Context;
using Coupon.Infrastructure.Repositories.Generic;

namespace Coupon.Infrastructure.Repositories.Descount;

public class AddCategoryToDescountRepository:GenericRepository<AddCategoryToDiscount>,IAddCategoryToDescountRepository
{
    private readonly DbCoupon _context;

    public AddCategoryToDescountRepository(DbCoupon context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> CreateWithcheck(AddCategoryToDiscount discounts)
    {
        try
        {
            await _context.AddAsync(discounts);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            return false;
        }
    }
}