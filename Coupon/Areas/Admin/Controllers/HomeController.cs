using Microsoft.AspNetCore.Mvc;

namespace Coupon.Areas.Admin.Controllers;
 
public class HomeController:BaseControllerArea
{
    public IActionResult Index()
    {
        return View();
    }
}