using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServiceOwl_DataAccess.DTO;
using ServiceOwl_DataAccess.IRepository;
using ServiceOwl_Domain.Models;

namespace ServiceOwl_DataAccess.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Create(CategoryDto categoryDto)
        {
            try
            {
                var category = _mapper.Map<CategoryDto, Category>(categoryDto);
                category.CreatedDate = DateTime.Now;
                var objAdded = _dbContext.Categories.Add(category);
                await _dbContext.SaveChangesAsync();

                return _mapper.Map<Category, CategoryDto>(objAdded.Entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
                if (category == null)
                {
                    return 0;
                }

                _dbContext.Categories.Remove(category);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            try
            {
                return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(_dbContext.Categories);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoryDto> GetById(int id)
        {
            try
            {
                var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
                if (category != null)
                {
                    return _mapper.Map<Category, CategoryDto>(category);
                }

                return new CategoryDto();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoryDto> Update(CategoryDto categoryDto)
        {
            try
            {
                var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == categoryDto.Id);
                if (category != null)
                {
                    category.Name = categoryDto.Name;
                    category.Description = categoryDto.Description;
                    _dbContext.Categories.Update(category);

                    await _dbContext.SaveChangesAsync();

                    return _mapper.Map<Category, CategoryDto>(category);
                }
                else
                {
                    return new CategoryDto();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
