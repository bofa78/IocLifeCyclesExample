using IocLifeCyclesExample.Interfaces;

namespace IocLifeCyclesExample.Services
{
    public class TransientService : ILifeCycleService
    {
        private Guid _id;

        public TransientService(ILogger<TransientService> logger)
        {
            _id = Guid.NewGuid();
            logger.LogInformation($"Transient has called - {_id}");
        }

        public Guid GetGuid()
        {
            return _id;
        }
    }
}
