using Microsoft.AspNetCore.Identity;

namespace Coupon.Domain.Entities.identity;

public class ApplicationUser:IdentityUser
{
    public string codemeli { get; set; }
}