using DockerNlayer.Core.Data.Repository;
using DockerNlayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DockerNlayer.Core.Data.UnitOfWork
{
    public interface IUnitofWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, IEntity;
        int SaveChanges();
    }
}
