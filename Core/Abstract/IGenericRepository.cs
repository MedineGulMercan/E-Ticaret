using Core.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Core.Abstract
{
    public interface IGenericRepository <T> where T : BaseEntity
    {
        Task<T> GetAsync(int Id);
        Task<IEnumerable<T>>? GetAllAsync();
        Task DeleteAsync(int Id);
        Task UpdateAsync(T? entity);
        Task CreateAsync(T? entity);
    }
}
