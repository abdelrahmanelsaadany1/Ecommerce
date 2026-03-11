using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(T item)
        {
           await _appDbContext.Set<T>().AddAsync(item);
           await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _appDbContext.Set<T>().FindAsync(id);
            _appDbContext.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _appDbContext.Set<T>().AsNoTracking().ToListAsync();
          
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(params System.Linq.Expressions.Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _appDbContext.Set<T>().AsNoTracking();

            // Apply includes
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)

        {
            return  await _appDbContext.Set<T>().FindAsync(id);
        }


        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _appDbContext.Set<T>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }
        public async Task UpdateAsync(T item)
        {
            var existing = await _appDbContext.Set<T>().FindAsync(item);
            _appDbContext.Entry(existing).CurrentValues.SetValues(item);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
