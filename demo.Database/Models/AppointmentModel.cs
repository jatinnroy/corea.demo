using demo.Database.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace demo.Database.Models
{
    public class AppointmentModel
    {
        public int? Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int HealthcareProfessionalId { get; set; }

        [Required(ErrorMessage = "Start time is required.")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "End time is required.")]
        public DateTime EndTime { get; set; }

        public StatusEnum Status { get; set; }

    }
}
