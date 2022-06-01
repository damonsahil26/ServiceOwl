using ServiceOwl_Application.Service.IService;
using ServiceOwl_DataAccess.DTO;
using ServiceOwl_DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOwl_Application.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<CategoryDto> Create(CategoryDto category)
        {
            try
            {
                return _categoryRepository.Create(category);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<int> Delete(int id)
        {
            try
            {
                return _categoryRepository.Delete(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<IEnumerable<CategoryDto>> GetAll()
        {
            try
            {
                return _categoryRepository.GetAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<CategoryDto> GetById(int id)
        {
            try
            {
                return _categoryRepository.GetById(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<CategoryDto> Update(CategoryDto category)
        {
            try
            {
                return _categoryRepository.Update(category);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
