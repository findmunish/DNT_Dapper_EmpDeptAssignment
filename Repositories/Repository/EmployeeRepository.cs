using Dapper;
using DapperAssignment;
using DapperAssignment.Dto;
using EfAssignmentDapper.Entities;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class EmployeeRepository : Repository<Employee, EmployeeForCreationDto, EmployeeForUpdateDto>, IEmployeeRepository
    {
        private static readonly string tableName = "Employees";
        private static readonly string pKey = "EmpId";

        public EmployeeRepository(DapperContext context) : base(context, tableName, pKey)
        {
        }

        //public async Task<IEnumerable<Employee>> GetEmployees()
        //{
        //    return await GetAll();
        //}

        //public async Task<Employee> GetEmployee(int id)
        //{
        //    return await GetById(id);
        //}

        public async Task<int> CreateEmployee(EmployeeForCreationDto employeeDto)
        {
            string strEntities = $"(Name, Address, ImagePath, DeptId) VALUES (@Name, @Address, @ImagePath, @DeptId)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", employeeDto.Name, DbType.String);
            parameters.Add("Address", employeeDto.Address, DbType.String);
            parameters.Add("ImagePath", employeeDto.ImagePath, DbType.String);
            parameters.Add("DeptId", employeeDto.DeptId, DbType.Int64);

            return await Create(parameters, strEntities);
        }

        public async Task UpdateEmployee(int id, EmployeeForUpdateDto employeeDto)
        {
            string setEntities = $"SET Name = @Name, Address = @Address, ImagePath = @ImagePath, DeptId = @DeptId ";

            var parameters = new DynamicParameters();

            parameters.Add("Name", employeeDto.Name, DbType.String);
            parameters.Add("Address", employeeDto.Address, DbType.String);
            parameters.Add("ImagePath", employeeDto.ImagePath, DbType.String);
            parameters.Add("DeptId", employeeDto.DeptId, DbType.Int64);

            await Update(id, parameters, setEntities);
        }

        //public async Task DeleteEmployee(int id)
        //{
        //    await Delete(id);
        //}
    }
}