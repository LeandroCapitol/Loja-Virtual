using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services;

namespace VShop.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var productDto = await _productService.GetProducts();
            if (productDto is null)
                return NotFound("Product not found");

            return Ok(productDto);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get(int id)
        {
            var productDto = await _productService.GetProductById(id);
            if (productDto is null)
                return NotFound("Product not found");

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDto)
        {
            if (productDto is null)
                return BadRequest("Invalid Data");

            await _productService.AddProduct(productDto);

            return new CreatedAtRouteResult("GetProduct", new { id = productDto.id },
                    productDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDTO)
        {
            if (id != productDTO.id)
                return BadRequest("Data Invalid");

            if (productDTO is null)
                return BadRequest("Data Invalid");

            await _productService.UpdateProduct(productDTO);

            return Ok(productDTO);
        }

        [HttpDelete]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var productDto = await _productService.GetProductById(id);

            if (productDto is null)
                return NotFound("Product not found");

            await _productService.RemoveProduct(id);

            return Ok(productDto);
        }

    }
}
