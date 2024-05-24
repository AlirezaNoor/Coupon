using Coupon.Domain.Base;

namespace Coupon.Domain.Entities.Categories;

public class Category:BaseEntity
{
    public string CategoryName { get; set; }
    public string? Description { get; set; }
} 