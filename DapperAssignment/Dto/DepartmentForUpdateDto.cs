using System.ComponentModel.DataAnnotations;

namespace DapperAssignment.Dto
{
    public class DepartmentForUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}