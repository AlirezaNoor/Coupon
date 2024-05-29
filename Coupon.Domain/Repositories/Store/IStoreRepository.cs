using Coupon.Domain.Repositories.Generic;

namespace Coupon.Domain.Repositories.Store;

public interface IStoreRepository:IGenericRepository<Entities.Stores.Store>
{
    Task<IQueryable<Entities.Stores.Store>> GetAllQuery();
}