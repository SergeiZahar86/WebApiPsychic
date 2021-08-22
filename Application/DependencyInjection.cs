using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Notes.Application
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Регистрация медиатора и валидации. 
        /// Для этого вызывается 
        /// <value><see cref="ServiceCollectionExtensions.AddMediatR"/></value>
        /// и передается ему выполняемая сборка
        /// <value><see cref="Assembly.GetExecutingAssembly"/></value>
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
/*        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
*/    }
}
