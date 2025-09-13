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

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            var values = _productService.TProductCount();
            return Ok(values);
        }

        [HttpGet("ProductCountByHamburger")]    
        public IActionResult ProductCountByCategoryNameHamburger()
        {
            var values = _productService.TProductCountByCategoryNameHamburger();
            return Ok(values);
        }

        [HttpGet("ProductCountByDrink")]
        public IActionResult ProductCountByCategoryNameDrink()
        {
            var values = _productService.TProductCountByCategoryNameDrink();
            return Ok(values);
        }

        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            var values = _productService.TProductPriceAvg();
            return Ok(values);
        }

        [HttpGet("ProductNameByMaxPrice")]
        public IActionResult ProductNameByMaxPrice()
        {
            var values = _productService.TProductNameByMaxPrice();
            return Ok(values);
        }

        [HttpGet("ProductNameByMinPrice")]
        public IActionResult ProductNameByMinPrice()
        {
            var values = _productService.TProductNameByMinPrice();
            return Ok(values);
        }

        [HttpGet("ProductAvgPriceByHamburger")]
        public IActionResult ProductAvgPriceByHamburger()
        {
            var values = _productService.TProductAvgPriceByHamburger();
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TAdd(_mapper.Map<Product>(createProductDto));
            return Ok("Ürün Eklendi");
        }

        [HttpDelete("{id}")]
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
            _productService.TUpdate(_mapper.Map<Product>(updateProductDto));
            return Ok("Ürün Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(_mapper.Map<ResultProductDto>(value));
        }
    }
}
