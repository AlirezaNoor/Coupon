using Coupon.Domain.Entities.identity;
using Coupon.Domain.Repositories.Categories;
using Coupon.Domain.Repositories.Descount;
using Coupon.Domain.Repositories.Store;
using Coupon.Infrastructure.Context;
using Coupon.Infrastructure.Repositories.Category;
using Coupon.Infrastructure.Repositories.Descount;
using Coupon.Infrastructure.Repositories.Store;
using Coupon.Infrastructure.Repositories.Unitofworks;
using Microsoft.AspNetCore.Identity;
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
        serviceCollection.AddScoped<IStoreRepository, StoreRepository>();
        serviceCollection.AddScoped<IDesCountRepository, DesCountRepository>();
        serviceCollection.AddScoped< IAddCategoryToDescountRepository, AddCategoryToDescountRepository>();
    }
}