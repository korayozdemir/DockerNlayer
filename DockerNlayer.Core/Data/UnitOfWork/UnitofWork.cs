using DockerNlayer.Core.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DockerNlayer.Core.Data.UnitOfWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly DbContext context;
        private Dictionary<Type, object> repositories;

        public UnitofWork(DbContext _context)
        {
            context = _context;
            repositories = repositories ?? new Dictionary<Type, object>();
        }
        private bool disposed = false;

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        IRepository<T> IUnitofWork.GetRepository<T>()
        {
            if (repositories.Keys.Contains(typeof(T)))
            {
                return repositories[typeof(T)] as IRepository<T>;
            }
            var repository = new RepositoryBase<T>(context);
            repositories.Add(typeof(T), repository);
            return repository;
        }
    }
}
