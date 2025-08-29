using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;
        
        public  TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetAll());
            return Ok(values);
        }
        
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial
            {
                Name = createTestimonialDto.Name,
                Title = createTestimonialDto.Title,
                Comment = createTestimonialDto.Comment,
                Image = createTestimonialDto.Image,
                Status = createTestimonialDto.Status,
            });
            return Ok("Müşteri Yorum Bilgisi Eklendi");
        }
        
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value  = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Müşteri Yorum Bilgisi Silindi");
        }
        
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TUpdate(new Testimonial
            { 
                TestimonialID = updateTestimonialDto.TestimonialID,
                Name = updateTestimonialDto.Name,
                Title = updateTestimonialDto.Title,
                Comment = updateTestimonialDto.Comment,
                Image = updateTestimonialDto.Image,
                Status = updateTestimonialDto.Status,
               
            });
            return Ok("Müşteri Yorum Bilgisi Güncellendi");
            
        }
        
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }
        
        
         
    }
    
    
    }

    
    
    