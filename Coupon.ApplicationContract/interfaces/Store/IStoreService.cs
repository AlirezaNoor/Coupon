using Coupon.ApplicationContract.Dto.Store;

namespace Coupon.ApplicationContract.interfaces.Store;

public interface IStoreService
{
    Task CreateCategory(CreateStore categoryDto);
    Task UpdateCategory(UpdateStore categoryDto);
    Task Delete(long Id);
    Task<StoreDto> GetbyId(long Id);
    Task<IQueryable<StoreDto>> GetAll();
}