using Coupon.ApplicationContract.Dto.DisCount;
using Coupon.ApplicationContract.interfaces.Category;
using Coupon.ApplicationContract.interfaces.Descount;
using Coupon.ApplicationContract.interfaces.Store;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Coupon.Areas.Admin.Controllers;

public class DiscountController:BaseControllerArea
{
    private readonly IDesCountService _desCountService;
    private readonly ICategoriesService _categoriesService;
    private readonly IStoreService _storeService;
    private readonly IExcelService _excelService;

    public DiscountController(IDesCountService desCountService, ICategoriesService categoriesService, IStoreService storeService, IExcelService excelService)
    {
        _desCountService = desCountService;
        _categoriesService = categoriesService;
        _storeService = storeService;
        _excelService = excelService;
    }

    public async Task<IActionResult> Index()
    {
        var discounts = await _desCountService.GetAllDiscountsAsync();
        return View(discounts);
    }

   
    public async Task<IActionResult> Create()
    {
        ViewBag.Stores = new SelectList(await _storeService.GetAll(), "ID", "StoreName");
        ViewBag.Categories = new SelectList(await _categoriesService.GetAll(), "Id", "CategoryName");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDescount model)
    {
        if (ModelState.IsValid)
        {
            await _desCountService.CreateDiscountAsync(model);
            return RedirectToAction("Index","Home");
        }

        ViewBag.Stores = new SelectList(await _storeService.GetAll(), "Id", "Name");
        ViewBag.Categories = new SelectList(await _categoriesService.GetAll(), "Id", "Name");
        return View(model);
    }
    
    public async Task<IActionResult> Edit(long id)
    {
        var discount = await _desCountService.GetDiscountByIdAsync(id);
        if (discount == null) return NotFound();

        var model = new CreateDescount
        {
            CodeName = discount.CodeName,
            Description = discount.Description,
            Code = discount.Code,
            start = discount.start,
            End = discount.End,
            IsHot = discount.IsHot,
            IsActive = discount.IsActive,
            StorId = discount.StorId,
            CreateAddCategorytoDescountDtos =await _desCountService.GetAllCategoryforDiscount(discount.ID)
        };

        ViewBag.Stores = new SelectList(await _storeService.GetAll(), "ID", "StoreName");
        ViewBag.Categories = new SelectList(await _categoriesService.GetAll(), "Id", "CategoryName");
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(long id, CreateDescount model)
    {
        if (ModelState.IsValid)
        {
            await _desCountService.UpdateDiscountAsync(id, model);
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Stores = new SelectList(await _storeService.GetAll(), "ID", "StoreName");
        ViewBag.Categories = new SelectList(await _categoriesService.GetAll(), "Id", "CategoryName");
        return View(model);
    }
    public async Task<IActionResult> Delete(long id)
    {
        var discount = await _desCountService.GetDiscountByIdAsync(id);
        if (discount == null) return NotFound();

        return View(discount);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        await _desCountService.DeleteDiscountAsync(id);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> UploadExcelFile()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UploadExcelFile(IFormFile file)
    {
        var dataList = await _excelService.ReadExcelData(file);

        foreach (var item in dataList)
        {
            await _desCountService.CreateDiscountAsync(item);
 
        }
         
        return RedirectToAction("Index", "Home");
    }
}