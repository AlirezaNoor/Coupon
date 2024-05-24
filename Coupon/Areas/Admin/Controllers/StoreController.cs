using Coupon.ApplicationContract.Dto.Categories;
using Coupon.ApplicationContract.Dto.Store;
using Coupon.ApplicationContract.interfaces.Store;
using Coupon.Areas.Admin.Models.Paginated;
using Coupon.Domain.Entities.Stores;
using Coupon.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Coupon.Areas.Admin.Controllers;

public class StoreController:BaseControllerArea
{
    private readonly IStoreService _storeService;

    public StoreController(IStoreService storeService)
    {
        _storeService = storeService;
    }

    [HttpGet]
    public async Task<IActionResult> CreateStore()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateStore(CreateStore dto)
    {
        string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        string folderName = "uploads";
        var img = await dto.Imagefile.SaveFileAsync(rootPath, folderName);
        // Store store = new Store()
        // {
        //     StoreName = dto.StoreName,
        //     Description = dto.Description,
        //     imagePath = img
        // };
        dto.imagePath = img;
        await _storeService.CreateCategory(dto);
        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> Index(int? pageNumber)
    {
        var pageSize = 10; // تعداد آیتم‌های هر صفحه
        var store = await _storeService.GetAll();        
        var paginatedstore = await PaginatedList<StoreDto>.CreateAsync(store, pageNumber ?? 1, pageSize);
        return View(paginatedstore);
    }
}