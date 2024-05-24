using Coupon.Application.Services;
using Coupon.ApplicationContract.interfaces.Category;
using Microsoft.Extensions.DependencyInjection;

namespace Coupon.Application.Configuration;

public static class ApplicationConfig
{
    public static void ApplicationCofigmethod(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICategoriesService, CategoriesService>();
    }
}