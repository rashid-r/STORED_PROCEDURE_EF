using System.ComponentModel.DataAnnotations;

namespace STORED_PROCEDURE_EF.Dto
{
    public class UpdateEmpDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Department must be between 2 and 50 characters")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Salary must be a valid decimal number with up to 2 decimal places (e.g., 50000.00)")]
        public string Salary { get; set; }
    }
}
