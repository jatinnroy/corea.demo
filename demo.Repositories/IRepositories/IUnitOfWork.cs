namespace demo.Repositories.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        AppointmentRepository Appointment
        {
            get;
        }

        HealthcareProfessionalRepository HealthcareProfessional
        {
            get;
        }

        int SaveChanges();
    }
}
