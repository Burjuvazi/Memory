using Memory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Core.DataAccess
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null);
        Task<int> AddAsync(T Entity);
        Task<int> UpdateAsync(T Entity);
        Task<int> DeleteAsync(T Entity);
        Task<int> HardResetAsync(T Entity);
    }
}
