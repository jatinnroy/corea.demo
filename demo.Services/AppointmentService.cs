using demo.Database.Entities;
using demo.Database.Models;
using demo.Repositories.IRepositories;
using demo.Services.IServices;
using Mapster;

namespace demo.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryManager _repositoryManager;

        public AppointmentService(IUnitOfWork unitOfWork, IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Appointment>> ListAsync()
        {
            return await _unitOfWork.Appointment.ListAsync();
        }

        public async Task<Appointment> GetByIdAsync(int id)
        {
            return await _unitOfWork.Appointment.GetByIdAsync(id);
        }

        public async Task<List<Appointment>> GetAppointmetByHPIdAsync(int id)
        {
            return await _repositoryManager.AppointmentRepository.GetAppointmetByHPIdAsync(id);
        }

        public bool CheckDuplicateAppointment(int id, DateTime StartTime)
        {
            var anyAppointmentBooked = GetAppointmetByHPIdAsync(id);
            if (anyAppointmentBooked.Result.Count() > 0)
            {
                var value = anyAppointmentBooked.Result.Find(item => item.StartTime == StartTime);
                if (value != null && value.Id > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public async Task<int> AddAsync(AppointmentModel request)
        {
            if (CheckDuplicateAppointment(request.HealthcareProfessionalId, request.StartTime) == true) return 0;
            
            var model = request.Adapt<Appointment>();

            //comment by jatin
            //this actual set by global, or need to send in mobile but i changed to defualt
            model.CreatedBy = 1;
            model.CreatedOn = DateTime.Now;
            model.CreatedRoleId = 1;

            _unitOfWork.Appointment.AddAsync(model);
            _unitOfWork.SaveChanges();
            return model.Id;
        }

        public async Task<bool> UpdateAsync(AppointmentModel request)
        {
            if (CheckDuplicateAppointment(request.HealthcareProfessionalId, request.StartTime) == true) return false;

            bool result = false;
            if (request != null && request.Id > 0)
            {
                var data = await _unitOfWork.Appointment.GetByIdAsync(request.Id.Value);
                if (data != null)
                {
                    data.UserId = request.UserId;
                    data.HealthcareProfessionalId = request.HealthcareProfessionalId;
                    data.StartTime = request.StartTime;
                    data.EndTime = request.EndTime;

                    //comment by jatin
                    //this actual set by global, or need to send in mobile but i changed to defualt
                    data.ModifiedBy = 1;
                    data.ModifiedOn = DateTime.Now;
                    data.ModifiedRoleId = 1;

                    _unitOfWork.Appointment.Update(data);
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
                var data = await _unitOfWork.Appointment.GetByIdAsync(id);
                if (data != null && data.Id > 0)
                {
                    _unitOfWork.Appointment.Delete(data);
                    result = _unitOfWork.SaveChanges() > 0 ? true : false;
                    return result;
                }
                return result;
            }
            return result;
        }

    }
}
