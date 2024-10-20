using demo.Database.Models;
using demo.Database.Responses;
using demo.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
    [Authorize]
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentController : BaseController
    {
        private readonly IServiceManager _serviceManager;

        public AppointmentController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("list")]
        public async Task<IActionResult> ListAsync()
        {

            var response = await _serviceManager.AppointmentService.ListAsync();

            if (response != null && response.Count() > 0)
            {
                return Ok(new ResponseModel { Data = response, Status = true });
            }
            return Ok(new ResponseModel { Status = false, Message = "No record added yet." });
        }


        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {

            var response = await _serviceManager.AppointmentService.GetByIdAsync(id);

            if (response != null && response.Id > 0)
            {
                return Ok(new ResponseModel { Data = response, Status = true });
            }
            return Ok(new ResponseModel { Status = false, Message = "No record found." });
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(AppointmentModel request)
        {
            var response = await _serviceManager.AppointmentService.AddAsync(request);

            if (response > 0)
            {
                return Ok(new ResponseModel { Data = response, Status = true, Message = "Record created successfully!" });
            }
            return Ok(new ResponseModel { Status = false, Message = "No record created." });
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(AppointmentModel request)
        {
            var response = await _serviceManager.AppointmentService.UpdateAsync(request);

            if (response == true)
            {
                return Ok(new ResponseModel { Status = true, Message = "Record updated successfully!" });
            }
            return Ok(new ResponseModel { Status = false, Message = "No record updated." });
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _serviceManager.AppointmentService.DeleteAsync(id);

            if (response == true)
            {
                return Ok(new ResponseModel { Status = true, Message = "Record deleted successfully!" });
            }
            return Ok(new ResponseModel { Status = false, Message = "No record deleted." });
        }

    }
}
