using AutoMapper;
using Coupon.ApplicationContract.Dto.DisCount;
using Coupon.ApplicationContract.Dto.DisCount.AddCategoryToDesCount;
using Coupon.ApplicationContract.interfaces.Descount;
using Coupon.Domain.Entities.Descount;
using Coupon.Domain.Repositories.Descount;
using Coupon.Infrastructure.Context;
using Coupon.Infrastructure.Repositories.Unitofworks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Coupon.Application.Services.Descount;

public class DesCountService : IDesCountService
{
    private readonly DbCoupon _context;
    private readonly Iunitofwork _unitOfWork;
    private readonly IExcelService _excelService;

    public DesCountService(DbCoupon context, Iunitofwork unitOfWork, IExcelService excelService)
    {
        _context = context;
        _unitOfWork = unitOfWork;
        _excelService = excelService;
    }

    public async Task CreateDiscountAsync(CreateDescount dto)
    {
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            var discount = new Discounts
            {
                CodeName = dto.CodeName,
                Description = dto.Description,
                Code = dto.Code,
                start = dto.start,
                End = dto.End,
                IsHot = dto.IsHot,
                IsActive = dto.IsActive,
                StorId = dto.StorId
            };

            await _context.Discounts.AddAsync(discount);
            await _context.SaveChangesAsync();

            foreach (var categoryId in dto.CreateAddCategorytoDescountDtos)
            {
                var addCategoryToDiscount = new AddCategoryToDiscount
                {
                    DiscountId = discount.ID,
                    CategoryId = categoryId
                };
                await _context.AddCategoryToDiscounts.AddAsync(addCategoryToDiscount);
            }

            await _context.SaveChangesAsync();
            await _unitOfWork.CommitAsync();
        }
        catch
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }


    public async Task<IQueryable<DescountDTO>> GetAllDiscountsAsync()
    {
       return  _context.Discounts.Include(d => d.store).Select(x => new DescountDTO()
            {
                CodeName = x.CodeName,
                Description = x.Description,
                Code = x.Code,
                ID = x.ID,
                IsActive = x.IsActive,
                StorId = x.StorId,
                start = x.start,
                End = x.End,
                IsHot = x.IsHot,
            })
            .AsQueryable();
    }

    public async Task<DescountDTO> GetDiscountByIdAsync(long id)
    {
        var x = await _context.Discounts
            .FirstOrDefaultAsync(d => d.ID == id);


        return new DescountDTO()
        {
            ID = x.ID,
            IsActive = x.IsActive,
            StorId = x.StorId,
            start = x.start,
            End = x.End,
            IsHot = x.IsHot,
        };
    }

    public async Task UpdateDiscountAsync(long id, CreateDescount dto)
    {
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            var discount = await _context.Discounts.FindAsync(id);
            if (discount == null) return;

            discount.CodeName = dto.CodeName;
            discount.Description = dto.Description;
            discount.Code = dto.Code;
            discount.start = dto.start;
            discount.End = dto.End;
            discount.IsHot = dto.IsHot;
            discount.IsActive = dto.IsActive;
            discount.StorId = dto.StorId;

            _context.Discounts.Update(discount);
            await _context.SaveChangesAsync();

            var existingCategories =
                await _context.AddCategoryToDiscounts.Where(acd => acd.DiscountId == id).ToListAsync();
            _context.AddCategoryToDiscounts.RemoveRange(existingCategories);
            await _context.SaveChangesAsync();

            foreach (var categoryId in dto.CreateAddCategorytoDescountDtos)
            {
                var addCategoryToDiscount = new AddCategoryToDiscount
                {
                    DiscountId = discount.ID,
                    CategoryId = categoryId
                };
                await _context.AddCategoryToDiscounts.AddAsync(addCategoryToDiscount);
            }

            await _context.SaveChangesAsync();
            await _unitOfWork.CommitAsync();
        }
        catch
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }

    public async Task DeleteDiscountAsync(long id)
    {
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            var discount = await _context.Discounts.FindAsync(id);
            if (discount == null) return;

            _context.Discounts.Remove(discount);
            await _context.SaveChangesAsync();
            await _unitOfWork.CommitAsync();
        }
        catch
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }

    public async Task<List<long>> GetAllCategoryforDiscount(long Id)
    {
        var result = await _context.AddCategoryToDiscounts.Where(x => x.DiscountId == Id).Select(x => x.CategoryId)
            .ToListAsync();

        return result;
    }

    // public async Task CreatewithExecll(IFormFile file)
    // {
    //     try
    //     {
    //         await _unitOfWork.BeginTransactionAsync();
    //
    //         var dataList = await _excelService.ReadExcelData(file);
    //         var atlast = dataList;
    //         var create = atlast.Select(x => new Discounts()
    //         {
    //             CodeName =x.CodeName ,
    //             Description =x.Description ,
    //             start =x.start ,
    //             Code =x.Code ,
    //             End = x.End,
    //             IsActive =x.IsActive ,
    //             IsHot =x.IsHot ,
    //             StorId = x.StorId
    //         });
    //         await _context.AddRangeAsync(atlast);
    //         await _context.SaveChangesAsync();
    //         await _unitOfWork.CommitAsync();
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e);
    //         await _unitOfWork.RollbackAsync();
    //         throw;
    //     }
    // }
}