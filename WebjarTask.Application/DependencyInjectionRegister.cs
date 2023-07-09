using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebjarTask.Application.Common.Behavior;

namespace WebjarTask.Application
{
    public static class DependencyInjectionRegister
    {
        public static IServiceCollection AddApplication(this IServiceCollection Services)
        {
            Services.AddMediatR(typeof(DependencyInjectionRegister).Assembly);
            Services.AddHttpClient();
            Services.AddSession();
            Services.AddHttpContextAccessor();
            Services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return Services;
        }
    }
}
