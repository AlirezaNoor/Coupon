using Coupon.ApplicationContract.Dto.DisCount;
using Coupon.ApplicationContract.interfaces.Descount;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

namespace Coupon.Application.Services.Descount;

public class ExcelService:IExcelService
{
    public async Task<List<CreateDescount>> ReadExcelData(IFormFile file)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        var dtoList = new List<CreateDescount>();

        using (var stream = new MemoryStream())
        {
            await file.CopyToAsync(stream);
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                if (worksheet != null)
                {
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++) // Assuming first row is header
                    {
                        var dto = new CreateDescount
                        {
                            CodeName = worksheet.Cells[row, 1].Value.ToString(),
                            Description = worksheet.Cells[row, 2].Value.ToString(),
                            Code = worksheet.Cells[row, 3].Value.ToString(),
                            start = DateTime.Parse(worksheet.Cells[row, 4].Value.ToString()),
                            End = DateTime.Parse(worksheet.Cells[row, 5].Value.ToString()),
                            IsHot = bool.Parse(worksheet.Cells[row, 6].Value.ToString()),
                            IsActive = bool.Parse(worksheet.Cells[row, 7].Value.ToString()),
                            StorId = long.Parse(worksheet.Cells[row, 8].Value.ToString()),
                            CreateAddCategorytoDescountDtos = GetdataFromExcell(worksheet.Cells[row, 9].Value.ToString())
                            
                            // You may need to adjust the indexes based on your Excel file structure
                        };

                        dtoList.Add(dto);
                    }
                }
            }
        }

        return dtoList;
    }

    private List<long> GetdataFromExcell(string? toString)
    {
        List<long> list = new List<long>();
      list=toString.Split(',')
          .Select(long.Parse)
          .ToList();

      return list;
    }
}