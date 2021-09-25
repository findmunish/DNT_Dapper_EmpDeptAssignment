using Dapper;
using DapperAssignment;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{   
    public class Repository<TEntity, TEntityCreateDto, TEntityUpdateDto> : IRepository<TEntity, TEntityCreateDto, TEntityUpdateDto>
        where TEntity : class
        where TEntityCreateDto : class
        where TEntityUpdateDto : class
    {
        protected DapperContext _context;
        protected string _tableName;
        protected string _pKey;

        public Repository(DapperContext context, string tableName, string pKey)
        {
            _context = context;
            _tableName = tableName;
            _pKey = pKey;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var query = $"SELECT * FROM {_tableName}";

            using (var connection = _context.CreateConnection())
            {
                var records = await connection.QueryAsync<TEntity>(query);
                return records.ToList();
            }
        }

        public async Task<TEntity> GetById(int id)
        {
            var query = $"SELECT * FROM {_tableName} WHERE {_pKey} = {id}";
            using (var connection = _context.CreateConnection())
            {
                var record = await connection.QuerySingleOrDefaultAsync<TEntity>(query, new { id });
                return record;
            }
        }

        public async Task<int> Create(DynamicParameters parameters, string setEntities)
        {
            var query = $"INSERT INTO {_tableName} {setEntities}";

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

        public async Task Update(int id, DynamicParameters parameters, string setEntities)
        {
            var query = $"UPDATE {_tableName} {setEntities} WHERE {_pKey} = {id}";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task Delete(int id)
        {
            var query = $"DELETE FROM {_tableName} WHERE {_pKey} = {id}";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
    }
}


