using UserApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UserApi.Repositories
{
    public class EFRepository<TEntity> : IEFRepository<TEntity>
                where TEntity : BaseEntity
    {
        private UserDBContext _context;
        private DbSet<TEntity> _dbset;

        public EFRepository(UserDBContext context)
        {
            _context = context;
            _dbset = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null) return _dbset.AsQueryable();

            return _dbset.Where(filter);
        }

        public async virtual Task<TEntity> CreateAsync(TEntity entity)
        {
            await _dbset.AddAsync(entity);

            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _dbset.Update(entity);

            return entity;
        }

        public virtual void Delete(TEntity entity)
        {
            _dbset.Remove(entity);
        }
    }
}