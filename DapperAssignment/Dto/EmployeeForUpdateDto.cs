using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DapperAssignment.Dto
{
    public class EmployeeForUpdateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }
    }
}
