using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using demo.Database.Enums;

namespace demo.Database.Entities
{
    public class Appointment
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int HealthcareProfessionalId { get; set; }

        [Required(ErrorMessage = "Start time is required.")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "End time is required.")]
        public DateTime EndTime { get; set; }

        public StatusEnum Status { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Int16 CreatedRoleId { get; set; }

        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Int16 ModifiedRoleId { get; set; }
    }
}
