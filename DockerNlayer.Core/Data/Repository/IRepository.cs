using DockerNlayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DockerNlayer.Core.Data.Repository
{
    public interface IRepository<T> where T : class, IEntity
    {
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null, bool tracking = false);
        IQueryable<T> Get(params Expression<Func<T, object>>[] includes);
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null,
                          Expression<Func<T, object>> include = null);
        IQueryable<T> Get
            (
                    Expression<Func<T, bool>> filter = null,
                    Expression<Func<T, object>> include = null,
                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                    int? skip = null,
                    int? take = null
            );
    }
}
