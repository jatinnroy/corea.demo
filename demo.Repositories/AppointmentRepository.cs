using demo.Database.Entities;
using demo.Database;
using demo.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace demo.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(DemoDBContext demoDBContext) : base(demoDBContext)
        {

        }
        public async Task<List<Appointment>> GetAppointmetByHPIdAsync(int id)
        {
            return await _demoDBContext.Appointment.Where(t => t.HealthcareProfessionalId == id).ToListAsync();
        }
    }
}