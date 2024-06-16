using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coupon.Areas.Admin.Controllers;
 
public class HomeController:BaseControllerArea
{
    [Authorize]
    public IActionResult Index()
    {
        return View();
    }
}