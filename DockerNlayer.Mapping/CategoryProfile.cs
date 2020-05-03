using DockerNlayer.DTO;
using DockerNlayer.Entity;
using DockerNlayer.Mapping.ConfigProfile;
using System;
using System.Collections.Generic;
using System.Text;

namespace DockerNlayer.Mapping
{
    public class CategoryProfile : ProfileBase
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
