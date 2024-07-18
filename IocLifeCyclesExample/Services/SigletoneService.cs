using IocLifeCyclesExample.Interfaces;

namespace IocLifeCyclesExample.Services
{
    public class SigletoneService : ILifeCycleService
    {
        private Guid _id;

        public SigletoneService(ILogger<SigletoneService> logger)
        {
            _id = Guid.NewGuid();
            logger.LogInformation($"Singleton has called - {_id}");
        }

        public Guid GetGuid()
        {
            return _id;
        }
    }
}
