using Coupon.ApplicationContract.Dto.Categories;
using Coupon.ApplicationContract.interfaces.Category;
using Coupon.Areas.Admin.Models.Paginated;
using Microsoft.AspNetCore.Mvc;

namespace Coupon.Areas.Admin.Controllers;

public class CategoryController:BaseControllerArea
{
    private readonly ICategoriesService _categoriesService;

    public CategoryController(ICategoriesService categoriesService)
    {
        _categoriesService = categoriesService;
    }
    
    public async Task<IActionResult> Index(int? pageNumber)
    {
        var pageSize = 10; // تعداد آیتم‌های هر صفحه
        var products = await _categoriesService.GetAll();        
        var paginatedProducts = await PaginatedList<CategoryDto>.CreateAsync(products, pageNumber ?? 1, pageSize);
        return View(paginatedProducts);
    }

    [HttpGet]
    public async Task<IActionResult> CreateCategroy()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategroy(CreateCategoryDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        await _categoriesService.CreateCategory(dto);
        return RedirectToAction("Index", "Home");

    }
}