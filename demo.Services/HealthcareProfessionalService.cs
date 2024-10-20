using demo.Database.Entities;
using demo.Database.Models;
using demo.Repositories.IRepositories;
using demo.Services.IServices;
using Mapster;

namespace demo.Services
{
    public class HealthcareProfessionalService : IHealthcareProfessionalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryManager _repositoryManager;

        public HealthcareProfessionalService(IUnitOfWork unitOfWork, IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<HealthcareProfessional>> ListAsync()
        {
            return await _unitOfWork.HealthcareProfessional.ListAsync();
        }

        public async Task<HealthcareProfessional> GetByIdAsync(int id)
        {
            return await _unitOfWork.HealthcareProfessional.GetByIdAsync(id);
        }

        public async Task<int> AddAsync(HealthcareProfessionalModel request)
        {
            var model = request.Adapt<HealthcareProfessional>();
            _unitOfWork.HealthcareProfessional.AddAsync(model);

            //comment by jatin
            //this actual set by global, or need to send in mobile but i changed to defualt
            model.CreatedBy = 1;
            model.CreatedOn = DateTime.Now;
            model.CreatedRoleId = 1;


            _unitOfWork.SaveChanges();
            return model.Id;
        }

        public async Task<bool> UpdateAsync(HealthcareProfessionalModel request)
        {
            bool result = false;
            if (request != null && request.Id > 0)
            {
                var data = await _unitOfWork.HealthcareProfessional.GetByIdAsync(request.Id.Value);
                if (data != null)
                {
                    data.Name = request.Name;
                    data.Title = request.Title;
                    data.Specialty = request.Specialty;


                    //comment by jatin
                    //this actual set by global, or need to send in mobile but i changed to defualt
                    data.ModifiedBy = 1;
                    data.ModifiedOn = DateTime.Now;
                    data.ModifiedRoleId = 1;
                    _unitOfWork.HealthcareProfessional.Update(data);
                    result = _unitOfWork.SaveChanges() > 0 ? true : false;
                    return result;
                }
                return result;
            }
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool result = false;
            if (id > 0)
            {
                var data = await _unitOfWork.HealthcareProfessional.GetByIdAsync(id);
                if (data != null && data.Id > 0)
                {
                    _unitOfWork.HealthcareProfessional.Delete(data);
                    result = _unitOfWork.SaveChanges() > 0 ? true : false;
                    return result;
                }
                return result;
            }
            return result;
        }

    }
}
