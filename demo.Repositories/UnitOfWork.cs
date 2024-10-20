using demo.Database;
using demo.Repositories.IRepositories;

namespace demo.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DemoDBContext _demoDBContext;

        public UnitOfWork(DemoDBContext demoDBContext)
        {
            _demoDBContext = demoDBContext;
            Appointment = new AppointmentRepository(_demoDBContext);
            HealthcareProfessional = new HealthcareProfessionalRepository(_demoDBContext);
        }

        public AppointmentRepository Appointment { get; private set; }
        public HealthcareProfessionalRepository HealthcareProfessional { get; private set; }

        public void Dispose()
        {
            _demoDBContext.Dispose();
        }
        
        public int SaveChanges()
        {
            int id = 0;
            using (var transaction = _demoDBContext.Database.BeginTransaction())
            {
                try
                {
                    id = _demoDBContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    id = 0;
                    transaction.Rollback();
                }
            }
            return id;
        }
    }
}
