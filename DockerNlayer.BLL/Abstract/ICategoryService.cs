using DockerNlayer.Core.Services;
using DockerNlayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DockerNlayer.BLL.Abstract
{
    public interface ICategoryService : IServiceBase
    {
        List<CategoryDTO> getAll();
        CategoryDTO getCategory(int categoryId);
        List<CategoryDTO> getCategoryNameList(string categoryName);
        CategoryDTO newCategory(CategoryDTO category);
        CategoryDTO updateCategory(CategoryDTO category);
        bool deleteCategory(int categoryId);
    }
}
