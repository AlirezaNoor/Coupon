using Coupon.Domain.Entities.Categories;
using Coupon.Domain.Entities.Descount;
using Coupon.Domain.Entities.Stores;
using Microsoft.EntityFrameworkCore;

namespace Coupon.Infrastructure.Context;

public class DbCoupon:DbContext
{
    public DbCoupon(DbContextOptions<DbCoupon> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Discounts> Discounts { get; set; }
    public DbSet<AddCategoryToDiscount> AddCategoryToDiscounts { get; set; }
}