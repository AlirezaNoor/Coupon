using Microsoft.AspNetCore.Mvc;

namespace Coupon.Areas.Admin.Controllers;
[Area("Admin")]
public class HomeController:Controller
{
    public IActionResult Index()
    {
        return View();
    }
}