using Coupon.Domain.Entities.Descount;
using Coupon.Domain.Repositories.Descount;
using Coupon.Infrastructure.Context;
using Coupon.Infrastructure.Repositories.Generic;

namespace Coupon.Infrastructure.Repositories.Descount;

public class DesCountRepository : GenericRepository<Discounts>, IDesCountRepository
{
    private readonly DbCoupon _context;

    public DesCountRepository(DbCoupon context) : base(context)
    {
        _context = context;
    }

    public async Task<IQueryable<Discounts>> GetAllQuery()
    {
        return _context.Discounts.AsQueryable();
    }

    public async Task<long> CreateWithcheck(Discounts discounts)
    {
        try
        {
          var test =await _context.AddAsync(discounts);
            return 1 ;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            return 0;
        }
    }
}