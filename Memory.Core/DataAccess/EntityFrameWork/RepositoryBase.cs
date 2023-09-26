using Memory.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Core.DataAccess.EntityFrameWork
{
    public class RepositoryBase<T> : IRepository<T> where T : class, IEntity, new()
    {
        DbContext _db;
        DbSet<T> _dbset;

        public RepositoryBase(DbContext db)
        {
            _db = db;
            _dbset = db.Set<T>();
           
        }

        public Task<int> AddAsync(T Entity)
        {
            _dbset.Add(Entity);
            return _db.SaveChangesAsync();          
        }

        public Task<int> DeleteAsync(T Entity)
        {
            Entity.IsDeleted = true;
            _dbset.Update(Entity);
            return _db.SaveChangesAsync(); 
        }

        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? _dbset.Where(x => x.IsDeleted == false).ToListAsync() : _dbset.Where(expression).Where(x => x.IsDeleted == false).ToListAsync(); 
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return _dbset.AsNoTracking<T>().FirstOrDefaultAsync(expression);
        }

        public Task<int> HardResetAsync(T Entity)
        {
            _dbset.Remove(Entity);
            return _db.SaveChangesAsync();
        }

        public Task<int> UpdateAsync(T Entity)
        {
            _dbset.Update(Entity);
            return _db.SaveChangesAsync();
        }
    }
}
