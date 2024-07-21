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
        IIocLifeCyclesExampleService iocLifeCyclesExampleService) : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(Summary = $"The DI injected the scoped, singleton and transient implementation of ILifeCycleService two times and we get back the GUIDs they created when the DI constructed it")]
        public IocLifeCyclesExampleResponseModel Get()
        {
            var result = iocLifeCyclesExampleService.GetGuids();

            logger.LogInformation(message: System.Text.Json.JsonSerializer.Serialize(result));

            return result;
        }
    }
}
