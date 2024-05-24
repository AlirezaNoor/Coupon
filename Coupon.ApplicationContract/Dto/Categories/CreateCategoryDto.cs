using System.ComponentModel.DataAnnotations;

namespace Coupon.ApplicationContract.Dto.Categories;

public class CreateCategoryDto
{
    [Required(ErrorMessage = "موضوع دسته بندی باید وارد شود")]
    [StringLength(60, ErrorMessage = "باید حداکثر شصت کاراکتر باشد")]

    public string CategoryName { get; set; }

    public string? Description { get; set; }
}