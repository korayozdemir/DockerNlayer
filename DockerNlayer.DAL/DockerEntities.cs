using DockerNlayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DockerNlayer.DAL
{
    public class DockerEntities : DbContext
    {
        public DockerEntities(DbContextOptions<DockerEntities> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
