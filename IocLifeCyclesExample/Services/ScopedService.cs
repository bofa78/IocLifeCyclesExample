using IocLifeCyclesExample.Interfaces;

namespace IocLifeCyclesExample.Services
{
    public class ScopedService : ILifeCycleService
    {
        private Guid _id;

        public ScopedService(ILogger<ScopedService> logger)
        {
            _id = Guid.NewGuid();
            logger.LogInformation($"Scoped has called - {_id}");
        }

        public Guid GetGuid()
        {
            return _id;
        }
    }
}
