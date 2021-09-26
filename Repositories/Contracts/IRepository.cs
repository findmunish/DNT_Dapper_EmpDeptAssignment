using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepository<TEntity, TEntityCreateDto, TEntityUpdateDto>
        where TEntity: class
        where TEntityCreateDto : class
        where TEntityUpdateDto : class
    {
        public Task<IEnumerable<TEntity>> GetAll();
        public Task<TEntity> GetById(int id);
        public Task<int> Create(DynamicParameters parameters, string setEntities);
        public Task Update(int id, DynamicParameters parameters, string setEntities);
        public Task Delete(int id);
    }
}