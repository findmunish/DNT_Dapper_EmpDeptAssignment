using DapperAssignment.Dto;
using EfAssignmentDapper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IDepartmentRepository : IRepository<Department, DepartmentForCreationDto, DepartmentForUpdateDto>
    {
        //public Task<IEnumerable<Department>> GetDepartments();
        //public Task<Department> GetDepartment(int id);
        public Task<int> CreateDepartment(DepartmentForCreationDto department);
        public Task UpdateDepartment(int id, DepartmentForUpdateDto company);
        //public Task DeleteDepartment(int id);
    }
}