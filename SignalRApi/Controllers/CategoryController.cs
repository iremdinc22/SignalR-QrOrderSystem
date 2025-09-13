using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetAll());
            return Ok(values);
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            var values = _categoryService.TCategoryCount();
            return Ok(values);
        }
        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            var values = _categoryService.TActiveCategoryCount();
            return Ok(values);
        }

        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            var values = _categoryService.TPassiveCategoryCount();
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TAdd(value);
            return Ok("Kategori Eklendi");
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetById(id);
             _categoryService.TDelete(value);
            return Ok("Kategori Silindi");
        }
        
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(value);
            return Ok("Kategori Güncellendi");
            
        }
        
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            return Ok(_mapper.Map<GetCategoryDto>(value));
        }
        
        
     

         
    }

    
    
    }
