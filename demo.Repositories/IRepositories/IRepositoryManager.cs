namespace demo.Repositories.IRepositories
{
    public interface IRepositoryManager
    {
        IAppointmentRepository AppointmentRepository { get; }
        IHealthcareProfessionalRepository HealthcareProfessionalRepository { get; }
    }
}
