using DockerNlayer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DockerNlayer.Core.Data.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext context;
        public RepositoryBase(DbContext _context)
        {
            context = _context;
        }
        public T Add(T entity)
        {
            return context.Set<T>().Add(entity) as T;
        }

        public void Delete(T entity)
        {
            var dbSet = context.Set<T>();
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        protected virtual IQueryable<T> GetQueryble(Expression<Func<T, bool>> filter = null,
            Expression<Func<T, object>> include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? skip = null, int? take = null, bool tracking = false)
        {
            IQueryable<T> query = context.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (include != null)
            {
                query = query.Include(include);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }
            if (!tracking)
            {
                return query;
            }
            return query.AsNoTracking();
        }

        public T Get(Expression<Func<T, bool>> filter = null)
        {
            return GetQueryble(filter).SingleOrDefault();
        }

        public T Get(Expression<Func<T, bool>> filter = null, bool tracking = false)
        {
            return GetQueryble(filter, null, null, null, null, tracking).FirstOrDefault();
        }

        public IQueryable<T> Get(Expression<Func<T, object>>[] includes = null)
        {
            IQueryable<T> query = context.Set<T>();
            foreach (var include in includes)
            {
                query.Include(include.Name);
            }
            return query;
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>> include = null)
        {
            return GetQueryble(filter, include, null);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null,
            Expression<Func<T, object>> include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? skip = null, int? take = null)
        {
            return GetQueryble(filter, include, orderBy, skip, take);
        }

        public IQueryable<T> GetAll()
        {
            return Get(null, null, null, null);
        }

        public void Update(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
