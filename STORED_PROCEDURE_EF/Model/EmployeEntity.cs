using System.ComponentModel.DataAnnotations;

namespace STORED_PROCEDURE_EF.Model
{
    public class EmployeEntity
    {
        [Required(ErrorMessage = "ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "ID must be a positive integer")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public string Salary { get; set; }
        public string Message { get; set; }
    }
}
