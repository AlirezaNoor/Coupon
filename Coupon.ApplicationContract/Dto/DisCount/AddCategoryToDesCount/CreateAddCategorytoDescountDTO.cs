namespace Coupon.ApplicationContract.Dto.DisCount.AddCategoryToDesCount;

public class CreateAddCategorytoDescountDTO
{
    public long CategoryId { get; set; } // کلید خارجی به جدول Category
  

    public long DiscountId { get; set; } // کلید خارجی به جدول Discounts
}