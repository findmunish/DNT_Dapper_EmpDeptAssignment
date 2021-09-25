using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperAssignment.Dto
{
    public class DepartmentForCreationDto
    {
        [Required]
        public string Name { get; set; }
    }
}
