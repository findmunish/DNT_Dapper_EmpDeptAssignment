using DapperAssignment.Dto;
using EfAssignmentDapper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IEmployeeRepository : IRepository<Employee, EmployeeForCreationDto, EmployeeForUpdateDto>
    {
        //public Task<IEnumerable<Employee>> GetEmployees();
        //public Task<Employee> GetEmployee(int id);
        public Task<int> CreateEmployee(EmployeeForCreationDto department);
        public Task UpdateEmployee(int id, EmployeeForUpdateDto company);
        //public Task DeleteEmployee(int id);
    }
}