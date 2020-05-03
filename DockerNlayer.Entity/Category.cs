using DockerNlayer.Core.Entities;

namespace DockerNlayer.Entity
{
    public class Category : IEntity
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
