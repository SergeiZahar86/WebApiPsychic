using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WebApiPsychic
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Регистрация медиатора
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }

    }
}
