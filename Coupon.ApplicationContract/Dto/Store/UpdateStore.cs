using Microsoft.AspNetCore.Http;

namespace Coupon.ApplicationContract.Dto.Store;

public class UpdateStore
{
    public long Id { get; set; }
    public string StoreName { get; set; }
    public string? Description { get; set; }
    public IFormFile  Imagefile { get; set; }
    public string  imagePath { get; set; }
}