using Bootcamp.API.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.API.Configurations
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            //ModelStateInvalidFilter'ı devre dışı bırakır. ValidationFilter'ı kullanmak için
            services.Configure<ApiBehaviorOptions>(x => { x.SuppressModelStateInvalidFilter = true; });
            
            //ValidationFilter tüm Controllerda uygulansın
            services.AddControllers(x => x.Filters.Add<ValidationFilter>());

            services.AddScoped(typeof(NotFoundFilter<>));
            services.AddScoped(typeof(ValidationFilter));

            return services;
        }
    }
}
