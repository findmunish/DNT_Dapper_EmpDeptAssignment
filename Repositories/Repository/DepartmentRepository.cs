using Dapper;
using DapperAssignment;
using DapperAssignment.Dto;
using EfAssignmentDapper.Entities;
using Repositories.Contracts;
using System.Data;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class DepartmentRepository : Repository<Department, DepartmentForCreationDto, DepartmentForUpdateDto>, IDepartmentRepository
    {
        private static readonly string tableName = "Departments";
        private static readonly string pKey = "DeptId";

        public DepartmentRepository(DapperContext context) : base(context, tableName, pKey) { }

        public async Task<int> CreateDepartment(DepartmentForCreationDto department)
        {
            string strEntities = $"(Name) VALUES (@Name) ";

            var parameters = new DynamicParameters();

            parameters.Add("Name", department.Name, DbType.String);

            return await Create(parameters, strEntities);
        }

        public async Task UpdateDepartment(int id, DepartmentForUpdateDto department)
        {
            string setEntities = $"SET Name = @Name ";

            var parameters = new DynamicParameters();

            parameters.Add("DeptId", id, DbType.Int32);
            parameters.Add("Name", department.Name, DbType.String);

            await Update(id, parameters, setEntities);
        }
    }
}