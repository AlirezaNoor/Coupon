using System.ComponentModel.DataAnnotations.Schema;
using Coupon.Domain.Base;
using Coupon.Domain.Entities.Categories;

namespace Coupon.Domain.Entities.Descount;

public class AddCategoryToDiscount:BaseEntity
{
    public long CategoryId { get; set; } // کلید خارجی به جدول Category
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }

    public long DiscountId { get; set; } // کلید خارجی به جدول Discounts
    
    [ForeignKey("DiscountId")]
    public Discounts Discount { get; set; }
}