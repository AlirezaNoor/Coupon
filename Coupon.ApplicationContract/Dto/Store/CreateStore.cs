 
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Coupon.ApplicationContract.Dto.Store;

public class CreateStore
{
    [Required(ErrorMessage = "این فیلد خالی است")]
    public string StoreName { get; set; }
    public string? Description { get; set; }
    public IFormFile  Imagefile { get; set; }
    public string  imagePath { get; set; }
}