using demo.Repositories.IRepositories;
using demo.Services.IServices;

namespace demo.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAppointmentService> _lazyAppointmentService;
        private readonly Lazy<IHealthcareProfessionalService> _lazyHealthcareProfessionalService;

        public ServiceManager(IUnitOfWork unitOfWork, IRepositoryManager repositoryManager)
        {
            _lazyAppointmentService = new Lazy<IAppointmentService>(() => new AppointmentService(unitOfWork, repositoryManager));
            _lazyHealthcareProfessionalService = new Lazy<IHealthcareProfessionalService>(() => new HealthcareProfessionalService(unitOfWork, repositoryManager));
        }

        public IAppointmentService AppointmentService => _lazyAppointmentService.Value;
        public IHealthcareProfessionalService HealthcareProfessionalService => _lazyHealthcareProfessionalService.Value;
    }
}
