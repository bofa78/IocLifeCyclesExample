using IocLifeCyclesExample.Interfaces;
using IocLifeCyclesExample.Services;

namespace IocLifeCyclesExample.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddLifeCycleServices(this IServiceCollection services)
        {
            services.AddKeyedScoped<ILifeCycleService, ScopedService>(Constants.ServiceNames.Scoped);
            services.AddKeyedSingleton<ILifeCycleService, SigletoneService>(Constants.ServiceNames.Singleton);
            services.AddKeyedTransient<ILifeCycleService, TransientService>(Constants.ServiceNames.Transient);

            services.AddTransient<IIocLifeCyclesExampleService, IocLifeCyclesExampleService>();
        }
    }
}