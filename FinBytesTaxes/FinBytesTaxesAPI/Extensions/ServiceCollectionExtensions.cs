using FinBytesTaxesAPI.Models.Db;
using FinBytesTaxesAPI.Models.Dto;
using FinBytesTaxesAPI.Repositories;
using FinBytesTaxesAPI.Repositories.Interfaces;
using FinBytesTaxesAPI.Services;
using FinBytesTaxesAPI.Services.Interfaces;

namespace FinBytesTaxesAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services)
        {
            return services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<CreateCityTaxRuleDto, CityTaxRule>();
            });
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICitiesRepository, CitiesRepository>();
            services.AddScoped<ICityTaxRulesRepository, CityTaxRulesRepository>();

            return services;
        }

        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<ICityTaxRulesService, CityTaxRulesService>();

            return services;
        }
    }
}
