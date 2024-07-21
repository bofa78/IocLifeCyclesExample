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
                { nameof(scopedServiceB), scopedServiceB.GetGuid() },
                { nameof(singletonServiceA), singletonServiceA.GetGuid() },
                { nameof(singletonServiceB), singletonServiceB.GetGuid() },
                { nameof(transientServiceA), transientServiceA.GetGuid() },
                { nameof(transientServiceB), transientServiceB.GetGuid() }
            };

            logger.LogInformation(message: System.Text.Json.JsonSerializer.Serialize(result));
            return result;
        }
    }
}
