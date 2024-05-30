using Coupon.Domain.Entities.Categories;
using Coupon.Domain.Entities.Descount;
using Coupon.Domain.Entities.identity;
using Coupon.Domain.Entities.Stores;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Coupon.Infrastructure.Context;

public class DbCoupon:IdentityDbContext<ApplicationUser,ApplicationRole,string>
{
    public DbCoupon(DbContextOptions<DbCoupon> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Discounts> Discounts { get; set; }
    public DbSet<AddCategoryToDiscount> AddCategoryToDiscounts { get; set; }
}