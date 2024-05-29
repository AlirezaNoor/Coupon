using Coupon.Domain.Repositories.Store;
using Coupon.Infrastructure.Context;
using Coupon.Infrastructure.Repositories.Generic;

namespace Coupon.Infrastructure.Repositories.Store;

public class StoreRepository : GenericRepository<Domain.Entities.Stores.Store>, IStoreRepository
{
    private readonly DbCoupon _context;

    public StoreRepository(DbCoupon context) : base(context)
    {
        _context = context;
    }

    public async Task<IQueryable<Domain.Entities.Stores.Store>> GetAllQuery()
    {
        return   _context.Stores.AsQueryable();
    }
}