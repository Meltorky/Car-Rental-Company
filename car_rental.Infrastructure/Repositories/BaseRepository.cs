using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Application.Interfaces.IRepositories;
using car_rental.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace car_rental.Infrastructure.Repositories
{
    public class BaseRepository<T>(ApplicationDbContext _context) : IBaseRepository<T> where T : class
    {
        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task<List<T>> GetAll
            (params Func<IQueryable<T>, IIncludableQueryable<T, object>>[] includeExpressions)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();

            if (includeExpressions.Length > 0)
            {
                foreach (var includeExpression in includeExpressions)
                {
                    query = includeExpression(query);
                }
            }

            return await query.ToListAsync();
        }


        public async Task<T?> GetById(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public async Task<bool> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
