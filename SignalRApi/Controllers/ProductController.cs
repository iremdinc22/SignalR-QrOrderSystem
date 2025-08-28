using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly SignalRContext _context;

        // Dependency Injection ile gelen servisler
        public ProductController(IProductService productService, IMapper mapper, SignalRContext context)
        {
            _productService = productService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetAll());
            return Ok(values);
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var values = _context.Products
                .Include(x => x.Category)
                .Select(y => new ResultProductWithCategoryDto
                {
                    ProductID = y.ProductID,
                    ProductName = y.ProductName,
                    Description = y.Description,
                    Price = y.Price,
                    ImageUrl = y.ImageUrl,
                    ProductStatus = y.ProductStatus,
                    CategoryName = y.Category.CategoryName
                })
                .ToList();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TAdd(new Product
            {
                ProductName = createProductDto.ProductName,
                Price = createProductDto.Price,
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                ProductStatus = createProductDto.ProductStatus
            });
            return Ok("Ürün Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            if (value != null)
            {
                _productService.TDelete(value);
                return Ok("Ürün Silindi");
            }
            return NotFound("Ürün bulunamadı");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TUpdate(new Product
            {
                ProductID = updateProductDto.ProductID,
                ProductName = updateProductDto.ProductName,
                Price = updateProductDto.Price,
                Description = updateProductDto.Description,
                ImageUrl = updateProductDto.ImageUrl,
                ProductStatus = updateProductDto.ProductStatus
            });
            return Ok("Ürün Güncellendi");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }
    }
}
