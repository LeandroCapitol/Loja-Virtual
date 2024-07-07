using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categories = await _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
        {
            var categoriesProducts = await _categoryRepository.GetCategoriesProducts();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesProducts);
        }

        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var categoryId = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDTO>(categoryId);
            
        }

        public async Task AddCategory(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Create(category);
            categoryDTO.CategoryId = category.CategoryId;
        }

        public async Task UpdateCategory(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Update(category);
        }
        public async Task RemoveCategory(int id)
        {
            var categoryId = _categoryRepository.GetById(id); // Verificar metodo
            var category = _mapper.Map<Category>(categoryId);

            await _categoryRepository.Delete(category.CategoryId);
        }
    }
}
