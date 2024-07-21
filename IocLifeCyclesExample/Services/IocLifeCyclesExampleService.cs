using IocLifeCyclesExample.Interfaces;
using IocLifeCyclesExample.Models;

namespace IocLifeCyclesExample.Services
{
    public class IocLifeCyclesExampleService(
        ILogger<IocLifeCyclesExampleService> logger,
        [FromKeyedServices(Constants.ServiceNames.Scoped)] ILifeCycleService scopedServiceA,
        [FromKeyedServices(Constants.ServiceNames.Scoped)] ILifeCycleService scopedServiceB,
        [FromKeyedServices(Constants.ServiceNames.Singleton)] ILifeCycleService singletonServiceA,
        [FromKeyedServices(Constants.ServiceNames.Singleton)] ILifeCycleService singletonServiceB,
        [FromKeyedServices(Constants.ServiceNames.Transient)] ILifeCycleService transientServiceA,
        [FromKeyedServices(Constants.ServiceNames.Transient)] ILifeCycleService transientServiceB) : IIocLifeCyclesExampleService
    {
        public IocLifeCyclesExampleResponseModel GetGuids()
        {
            var result = new IocLifeCyclesExampleResponseModel();
            result.Services = new()
            {
                { nameof(scopedServiceA), scopedServiceA.GetGuid() },
                { "ScopedServiceB", scopedServiceB.GetGuid() },
                { "SingletonServiceA", singletonServiceA.GetGuid() },
                { "SingletonServiceB", singletonServiceB.GetGuid() },
                { "TransientServiceA", transientServiceA.GetGuid() },
                { "TransientServiceB", transientServiceB.GetGuid() }
            };

            logger.LogInformation(message: System.Text.Json.JsonSerializer.Serialize(result));
            return result;
        }
    }
}
