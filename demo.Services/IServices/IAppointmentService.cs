using demo.Database.Entities;
using demo.Database.Models;

namespace demo.Services.IServices
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> ListAsync();
        Task<Appointment> GetByIdAsync(int id);
        Task<int> AddAsync(AppointmentModel request);
        Task<bool> UpdateAsync(AppointmentModel request);
        Task<bool> DeleteAsync(int id);
    }
}
