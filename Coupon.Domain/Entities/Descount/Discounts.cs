using System.ComponentModel.DataAnnotations.Schema;
using Coupon.Domain.Base;
using Coupon.Domain.Entities.Stores;

namespace Coupon.Domain.Entities.Descount;

public class Discounts:BaseEntity
{
    public string CodeName { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public DateTime? start { get; set; }
    public DateTime? End { get; set; }
    public bool IsHot { get; set; }
    public bool IsActive { get; set; }
    public long StorId { get; set; }
    [ForeignKey("StorId")]
    public Store store { get; set; }
}