using DapperAssignment.Dto;
using EfAssignmentDapper.Entities;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IEmployeeRepository : IRepository<Employee, EmployeeForCreationDto, EmployeeForUpdateDto>
    {
        public Task<int> CreateEmployee(EmployeeForCreationDto department);
        public Task UpdateEmployee(int id, EmployeeForUpdateDto company);
    }
}