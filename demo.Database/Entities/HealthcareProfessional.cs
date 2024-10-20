using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace demo.Database.Entities
{
    public class HealthcareProfessional
    {
        [Required]
        public int Id { get; set; }

        //[MaxLength(200)]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(200, ErrorMessage = "The Name value cannot exceed 200 characters.")]
        public string? Name { get; set; }

        //[MaxLength(200)]
        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, ErrorMessage = "The Name value cannot exceed 200 characters.")]
        public string? Title { get; set; }

        //[MaxLength(200)]
        [Required(ErrorMessage = "Specialty is required")]
        [StringLength(200, ErrorMessage = "The Name value cannot exceed 200 characters.")]
        public string? Specialty { get; set; }


        [Required(ErrorMessage = "Created By is required.")]
        public int? CreatedBy { get; set; }

        [Required(ErrorMessage = "Created On is required.")]
        public DateTime? CreatedOn { get; set; }

        [Required(ErrorMessage = "Created Role Id is required.")]
        public Int16? CreatedRoleId { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public Int16? ModifiedRoleId { get; set; }
    }
}
