using AutoMapper;
using Coupon.ApplicationContract.Dto.Store;
using Coupon.ApplicationContract.interfaces.Store;
using Coupon.Domain.Repositories.Store;
using Coupon.Infrastructure.Repositories.Unitofworks;

namespace Coupon.Application.Services.Store;

public class StoreService : IStoreService
{
    private readonly IStoreRepository _storeRepository;
    private readonly Iunitofwork _unitofwork;
    private readonly IMapper _mapper;

    public StoreService(IStoreRepository storeRepository, Iunitofwork unitofwork, IMapper mapper)
    {
        _storeRepository = storeRepository;
        _unitofwork = unitofwork;
        _mapper = mapper;
    }

    public async Task CreateCategory(CreateStore categoryDto)
    {
        await _unitofwork.BeginTransactionAsync();

        await _storeRepository.AddAsync(_mapper.Map<Domain.Entities.Stores.Store>(categoryDto));
        await _unitofwork.SaveChangesAsync();
        await _unitofwork.CommitAsync();
        
    }

    public async Task UpdateCategory(UpdateStore categoryDto)
    {
        await _unitofwork.BeginTransactionAsync();
        _storeRepository.Update(_mapper.Map<Domain.Entities.Stores.Store>(categoryDto));
        await _unitofwork.SaveChangesAsync();
        await _unitofwork.CommitAsync();
    }

    public async Task Delete(long Id)
    {
        await _unitofwork.BeginTransactionAsync();

        var Get = await GetbyId(Id);
        _storeRepository.Delete(_mapper.Map<Domain.Entities.Stores.Store>(Get));
        await _unitofwork.SaveChangesAsync();
        await _unitofwork.CommitAsync();
    }

    public async Task<StoreDto> GetbyId(long Id)
    {
        var result = await _storeRepository.GetByIdAsync(Id);
        return _mapper.Map<StoreDto>(result);
    }

    public async Task<IQueryable<StoreDto>> GetAll()
    {
        var result = await _storeRepository.GetAllQuery();
        return result.Select(x => new StoreDto()
        {
            ID = x.ID,
            Description = x.Description,
            StoreName = x.StoreName,
            imagePath = x.imagePath
        }).AsQueryable();
    }
}