namespace Coupon.Domain.Base;

public class BaseEntity
{
    public long ID { get; set; }
    public DateTime CreationDate { get; set; }

    public BaseEntity()
    {
        CreationDate = DateTime.Now;
    }
}