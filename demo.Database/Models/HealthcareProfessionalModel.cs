using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace demo.Database.Models
{
    public class HealthcareProfessionalModel
    {
        public int? Id { get; set; }

        //  [MaxLength(200)]
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
    }
}
