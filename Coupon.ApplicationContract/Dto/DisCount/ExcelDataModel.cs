namespace Coupon.ApplicationContract.Dto.DisCount;

public class ExcelDataModel
{
    public string CodeName { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public bool IsHot { get; set; }
    public bool IsActive { get; set; }
    public long StoreId { get; set; }
}