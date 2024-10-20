using demo.Database.Entities;
using demo.Database.Models;

namespace demo.Services.IServices
{
    public interface IHealthcareProfessionalService
    {
        Task<IEnumerable<HealthcareProfessional>> ListAsync();
        Task<HealthcareProfessional> GetByIdAsync(int id);
        Task<int> AddAsync(HealthcareProfessionalModel request);
        Task<bool> UpdateAsync(HealthcareProfessionalModel request);
        Task<bool> DeleteAsync(int id);
    }
}
