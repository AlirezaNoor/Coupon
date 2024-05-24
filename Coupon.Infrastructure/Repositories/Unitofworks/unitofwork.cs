using Coupon.Infrastructure.Context;

namespace Coupon.Infrastructure.Repositories.Unitofworks;

public class unitofwork:Iunitofwork
{
    private readonly DbCoupon _coupon;

    public unitofwork(DbCoupon coupon)
    {
        _coupon = coupon;
    }

    public async Task SaveChanges()
    {
       await _coupon.SaveChangesAsync();
     
    }
}