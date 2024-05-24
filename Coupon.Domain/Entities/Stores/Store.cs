using Coupon.Domain.Base;

namespace Coupon.Domain.Entities.Stores;

public class Store:BaseEntity
{
    public string StoreName { get; set; }
    public string? Description { get; set; }
    public string  imagePath { get; set; }

}