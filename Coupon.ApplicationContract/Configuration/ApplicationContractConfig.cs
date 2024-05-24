using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Coupon.ApplicationContract.Configuration;

public static class ApplicationContractConfig
{
    public static void AppContractConfig(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}