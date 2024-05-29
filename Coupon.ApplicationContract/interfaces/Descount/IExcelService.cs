using Coupon.ApplicationContract.Dto.DisCount;
using Microsoft.AspNetCore.Http;

namespace Coupon.ApplicationContract.interfaces.Descount;

public interface IExcelService
{
    Task<List<CreateDescount>> ReadExcelData(IFormFile file);
}