using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebjarTask.Application.Common.Interfaces.Repository;
using WebjarTask.Application.Common.Interfaces.Services;
using WebjarTask.Infrastructure.Persistence;
using WebjarTask.Infrastructure.Persistence.Repository;
using WebjarTask.Infrastructure.Services;

namespace WebjarTask.Infrastructure
{
    public static class DependencyInjectionRegister
    {
        public static IServiceCollection AddPersistance(this IServiceCollection Services)
        {
            Services.AddDbContext<WebjarProductDbContext>(options =>
                options.UseSqlServer("server=.;database=WebjarTask;integrated security=true;Trusted_Connection=True;TrustServerCertificate=True;"));

            Services.AddScoped<IProductS, ProductS>();
            Services.AddScoped(typeof(IGenericR<>), typeof(GenericR<>));

            return Services;
        }
    }
}
