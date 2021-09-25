using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperAssignment.Dto
{
    public class DepartmentForUpdateDto
    {
        //public int DeptId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}