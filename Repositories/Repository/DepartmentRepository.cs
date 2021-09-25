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
    public class DepartmentRepository : IDepartmentRepository
    {
        protected DapperContext _context;

        public DepartmentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            var query = "SELECT * FROM Departments";

            using (var connection = _context.CreateConnection())
            {
                var departments = await connection.QueryAsync<Department>(query);
                return departments.ToList();
            }
        }

        public async Task<Department> GetDepartment(int id)
        {
            var query = "SELECT * FROM Departments WHERE DeptId = @Id";
            using (var connection = _context.CreateConnection())
            {
                var department = await connection.QuerySingleOrDefaultAsync<Department>(query, new { id });
                return department;
            }
        }

        public async Task<int> CreateDepartment(DepartmentForCreationDto department)
        {
            var query = "INSERT INTO Departments (Name) VALUES (@Name)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", department.Name, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, parameters);
            }

            //using (var connection = _context.CreateConnection())
            //{
            //    var id = await connection.QuerySingleAsync<int>(query, parameters);

            //    var createdDepartment = new Department
            //    {
            //        DeptId = id,
            //        Name = department.Name,
            //    };
            //    return createdDepartment;
            //}
        }

        public async Task UpdateDepartment(int id, DepartmentForUpdateDto department)
        {
            var query = "UPDATE Departments SET Name = @Name WHERE DeptId = @DeptId";
            var parameters = new DynamicParameters();
            parameters.Add("DeptId", id, DbType.Int32);
            parameters.Add("Name", department.Name, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDepartment(int id)
        {
            var query = "DELETE FROM Departments WHERE DeptId = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
    }
}

