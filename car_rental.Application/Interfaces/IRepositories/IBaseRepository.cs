using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental.Application.Interfaces.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetById(int Id);
        Task<List<T>> GetAll();
        Task Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
