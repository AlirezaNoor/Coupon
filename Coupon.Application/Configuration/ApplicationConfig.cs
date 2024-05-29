using Coupon.Application.Services;
using Coupon.Application.Services.Descount;
using Coupon.Application.Services.Store;
using Coupon.ApplicationContract.interfaces.Category;
using Coupon.ApplicationContract.interfaces.Descount;
using Coupon.ApplicationContract.interfaces.Store;
using Microsoft.Extensions.DependencyInjection;

namespace Coupon.Application.Configuration;

public static class ApplicationConfig
{
    public static void ApplicationCofigmethod(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICategoriesService, CategoriesService>();
        serviceCollection.AddScoped<IStoreService, StoreService>();
        serviceCollection.AddScoped<IDesCountService, DesCountService>();
        serviceCollection.AddScoped<IExcelService, ExcelService>();
    }
}