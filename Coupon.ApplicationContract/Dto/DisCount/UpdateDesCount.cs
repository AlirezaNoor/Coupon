namespace Coupon.ApplicationContract.Dto.DisCount;

public class UpdateDesCount
{
    public long ID { get; set; }
    public string CodeName { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public DateTime? start { get; set; }
    public DateTime? End { get; set; }
    public bool IsHot { get; set; }
    public bool IsActive { get; set; }
    public long StorId { get; set; }
}