using ChatApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Services
{
    public interface IGenericService<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<int> CountAsync();
        Task<T> DeleteAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync(PaginationModel paginationModel);
        Task<T> UpdateAsync(T entity);
    }
}
