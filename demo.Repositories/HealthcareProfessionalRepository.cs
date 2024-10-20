using demo.Database.Entities;
using demo.Database;
using demo.Repositories.IRepositories;

namespace demo.Repositories
{
    public class HealthcareProfessionalRepository : GenericRepository<HealthcareProfessional>, IHealthcareProfessionalRepository
    {
        public HealthcareProfessionalRepository(DemoDBContext demoDBContext) : base(demoDBContext) { }
    }
}
