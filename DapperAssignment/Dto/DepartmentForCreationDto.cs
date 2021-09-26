using System.ComponentModel.DataAnnotations;

namespace DapperAssignment.Dto
{
    public class DepartmentForCreationDto
    {
        [Required]
        public string Name { get; set; }
    }
}