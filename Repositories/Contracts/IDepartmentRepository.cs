using DapperAssignment.Dto;
using EfAssignmentDapper.Entities;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IDepartmentRepository : IRepository<Department, DepartmentForCreationDto, DepartmentForUpdateDto>
    {
        public Task<int> CreateDepartment(DepartmentForCreationDto department);
        public Task UpdateDepartment(int id, DepartmentForUpdateDto company);
    }
}