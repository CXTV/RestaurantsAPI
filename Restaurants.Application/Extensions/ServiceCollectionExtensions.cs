using Microsoft.Extensions.DependencyInjection;

namespace Restaurants.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            //1.获取应用程序程序集
            var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
            //2.注册所有MediatR处理程序
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
            //3.注册所有AutoMapper配置
            services.AddAutoMapper(applicationAssembly);
        }
    }
}
