using Bootcamp.Service.Categories;
using Bootcamp.Service.Categories.Validation;
using Bootcamp.Service.Products;
using Bootcamp.Service.Products.Validation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Bootcamp.Service
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<CategoryService>();
            services.AddScoped<ProductService>();

            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblyContaining<CategoryCreateValidator>();
            services.AddValidatorsFromAssemblyContaining<ProductCreateValidator>();

            return services;
        }
    }
}