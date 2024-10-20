namespace demo.Services.IServices
{
    public interface IServiceManager
    {
        IAppointmentService AppointmentService { get; }
        IHealthcareProfessionalService HealthcareProfessionalService { get; }
    }
}
