using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace car_rental.Application.Interfaces.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetById(int Id);
        Task<List<T>> GetAll();
        Task<List<T>> GetAll
            (params Func<IQueryable<T>, IIncludableQueryable<T, object>>[] includeExpressions);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
