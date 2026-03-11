using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public Task AddAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> GetAllAsync(params System.Linq.Expressions.Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public Task GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetByIdAsync(int id, params System.Linq.Expressions.Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T item)
        {
            throw new NotImplementedException();
        }
    }
}
