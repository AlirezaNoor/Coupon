using AutoMapper;
using Coupon.ApplicationContract.Dto.Categories;
using Coupon.ApplicationContract.interfaces.Category;
using Coupon.Domain.Entities.Categories;
using Coupon.Domain.Repositories.Categories;
using Coupon.Infrastructure.Repositories.Unitofworks;

namespace Coupon.Application.Services;

public class CategoriesService:ICategoriesService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly Iunitofwork _unitofwork;
    private readonly IMapper _mapper;

    public CategoriesService(ICategoryRepository categoryRepository, IMapper mapper, Iunitofwork unitofwork)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _unitofwork = unitofwork;
    }

    public async Task CreateCategory(CreateCategoryDto categoryDto)
    {
       await _categoryRepository.AddAsync(_mapper.Map<Category>(categoryDto));
        await _unitofwork.SaveChanges();
    }

    public async Task UpdateCategory(UpdateCategoryDto categoryDto)
    {
        _categoryRepository.Update(_mapper.Map<Category>(categoryDto));
        _unitofwork.SaveChanges();
    }

    public async Task Delete(long Id)
    {
        var catgeory =await GetbyId(Id);
        _categoryRepository.Delete(_mapper.Map<Category>(catgeory));
        _unitofwork.SaveChanges();
    }

    public async Task<CategoryDto> GetbyId(long Id)
    {
        return _mapper.Map<CategoryDto>(_categoryRepository.GetByIdAsync(Id));
    }

    public async Task<IQueryable<CategoryDto>> GetAll()
    {
        var all = await _categoryRepository.GetAllQuery();

        return all.Select(x => new CategoryDto()
        {
            Id = x.ID,
            Description = x.Description,
            CategoryName = x.CategoryName
        }).AsQueryable();
    }
}