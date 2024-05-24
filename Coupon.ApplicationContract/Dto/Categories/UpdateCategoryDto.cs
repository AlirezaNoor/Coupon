using System.ComponentModel.DataAnnotations;

namespace Coupon.ApplicationContract.Dto.Categories;

public class UpdateCategoryDto
{
    [Required(ErrorMessage = "شناسه مورد نظر معتبر نمی باشد")]
    public long Id { get; set; }
    [Required(ErrorMessage = "فیلد مورد نظر اجباری است.")]
    [StringLength(60, ErrorMessage = "باید حداکثر 60 کارکتر باشد")]
    public string CategoryName { get; set; }
    public string? Description { get; set; }
}