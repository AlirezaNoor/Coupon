using Coupon.Domain.Entities.Descount;
using Coupon.Domain.Repositories.Generic;

namespace Coupon.Domain.Repositories.Descount;

public interface IDesCountRepository:IGenericRepository<Discounts>
{
    Task<IQueryable<Discounts>> GetAllQuery();
    Task<long> CreateWithcheck(Discounts discounts);

}