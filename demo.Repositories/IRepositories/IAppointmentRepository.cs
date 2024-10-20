using demo.Database.Entities;

namespace demo.Repositories.IRepositories
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAppointmetByHPIdAsync(int id);
    }
}
