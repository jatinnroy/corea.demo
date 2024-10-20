using demo.Database;
using demo.Repositories.IRepositories;

namespace demo.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        public readonly Lazy<IAppointmentRepository> _lazAppointmentRepository;
        public readonly Lazy<IHealthcareProfessionalRepository> _lazIHealthcareProfessionalRepository;

        public RepositoryManager(DemoDBContext demoDBContext)
        {
            _lazAppointmentRepository = new Lazy<IAppointmentRepository>(() => new AppointmentRepository(demoDBContext));
            _lazIHealthcareProfessionalRepository = new Lazy<IHealthcareProfessionalRepository>(() => new HealthcareProfessionalRepository(demoDBContext));

        }

        public IAppointmentRepository AppointmentRepository => _lazAppointmentRepository.Value;
        public IHealthcareProfessionalRepository HealthcareProfessionalRepository => _lazIHealthcareProfessionalRepository.Value;

    }
}
