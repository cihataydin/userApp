using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UserApi.Repositories
{
    public interface IEFRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> CreateAsync(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);   
    }
}