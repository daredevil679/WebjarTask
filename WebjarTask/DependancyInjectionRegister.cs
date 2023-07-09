using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebjarTask.Common.Errors;
using WebjarTask.Common.Mappings;

namespace WebjarTask
{
    public static class DependancyInjectionRegister
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, WebjarTaskProblemDetailsFactory>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMappings();
            services.AddMvc()
                .AddSessionStateTempDataProvider();
            services.AddSession();
            return services;
        }
    }
}
