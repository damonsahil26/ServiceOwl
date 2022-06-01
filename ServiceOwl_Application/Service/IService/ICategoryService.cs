using ServiceOwl_DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOwl_Application.Service.IService
{
    public interface ICategoryService
    {
        Task<CategoryDto> Create(CategoryDto category);
        Task<int> Delete(int id);
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<CategoryDto> GetById(int id);
        Task<CategoryDto> Update(CategoryDto category);
    }
}
