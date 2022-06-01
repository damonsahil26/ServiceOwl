using ServiceOwl_DataAccess.DTO;
using ServiceOwl_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOwl_DataAccess.IRepository
{
    public interface ICategoryRepository
    {
        Task<CategoryDto> Create(CategoryDto categoryDto);
        Task<CategoryDto> Update(CategoryDto categoryDto);
        Task<int> Delete(int id);
        Task<CategoryDto> GetById(int id);
        Task<IEnumerable<CategoryDto>> GetAll();
    }
}
