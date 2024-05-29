using Coupon.Infrastructure.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Coupon.Infrastructure.Repositories.Unitofworks;

public class unitofwork:Iunitofwork
{
    private readonly DbCoupon _coupon;
    private IDbContextTransaction _transaction;

    public unitofwork(DbCoupon coupon)
    {
        _coupon = coupon;
    }

    // شروع تراکنش
    public async Task BeginTransactionAsync()
    {
        _transaction = await _coupon.Database.BeginTransactionAsync();
    }

    // تایید تراکنش
    public async Task CommitAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    // لغو تراکنش
    public async Task RollbackAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    // ذخیره تغییرات
    public async Task SaveChangesAsync()
    {
        await _coupon.SaveChangesAsync();
    }
}