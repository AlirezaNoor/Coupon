namespace Coupon.Infrastructure.Repositories.Unitofworks;

public interface Iunitofwork
{
    Task SaveChangesAsync();
    Task RollbackAsync();
    Task  CommitAsync();
    Task BeginTransactionAsync();
}