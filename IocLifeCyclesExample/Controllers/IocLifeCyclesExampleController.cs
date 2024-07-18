using IocLifeCyclesExample.Interfaces;
using IocLifeCyclesExample.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IocLifeCyclesExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IocLifeCyclesExampleController(
        ILogger<IocLifeCyclesExampleController> logger,
        [FromKeyedServices(Constants.ServiceNames.Scoped)] ILifeCycleService scopedServiceA,
        [FromKeyedServices(Constants.ServiceNames.Scoped)] ILifeCycleService scopedServiceB,
        [FromKeyedServices(Constants.ServiceNames.Singleton)] ILifeCycleService singletonServiceA,
        [FromKeyedServices(Constants.ServiceNames.Singleton)] ILifeCycleService singletonServiceB,
        [FromKeyedServices(Constants.ServiceNames.Transient)] ILifeCycleService transientServiceA,
        [FromKeyedServices(Constants.ServiceNames.Transient)] ILifeCycleService transientServiceB) : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(Summary = $"The DI injected the scoped, singleton and transient implementation of ILifeCycleService two times and we get back the GUIDs they created when the DI constructed it")]
        public IocLifeCyclesExampleResponseModel Get()
        {
            var result = new IocLifeCyclesExampleResponseModel();
            result.Services = new()
            {
                { "ScopedServiceA", scopedServiceA.GetGuid() },
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
