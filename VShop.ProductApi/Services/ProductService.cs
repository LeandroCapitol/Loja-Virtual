using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var products = await _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var productId = await _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(productId);

        }

        public async Task AddProduct(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            await _productRepository.Create(product);

            productDTO.CategoryId = product.CategoryId;
        }

        public async Task UpdateProduct(ProductDTO productDTO)
        {
            var category = _mapper.Map<Product>(productDTO);
            await _productRepository.Update(category);
        }
        public async Task RemoveProduct(int id)
        {
            var productId = _productRepository.GetById(id); // Verificar metodo
            var product = _mapper.Map<Product>(productId);

            await _productRepository.Delete(product.CategoryId);
        }

    }
}
