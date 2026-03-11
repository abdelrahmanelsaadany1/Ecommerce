using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T > where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, Object>>[] includes);
        Task GetByIdAsync(int id);
        Task GetByIdAsync(int id, params Expression<Func<T, Object>>[] includes);
      
        Task AddAsync (T item);
        Task UpdateAsync (T item);
        Task DeleteAsync (int id);

    }
}
