using Coupon.Domain.Repositories.Categories;
using Coupon.Infrastructure.Context;
using Coupon.Infrastructure.Repositories.Category;
using Coupon.Infrastructure.Repositories.Unitofworks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Coupon.Infrastructure.configuration;

public static class Dependency
{
    public static void DependencyMethod(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<DbCoupon>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
        serviceCollection.AddScoped<Iunitofwork, unitofwork>();
    }
}