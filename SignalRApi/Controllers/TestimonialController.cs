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
            _testimonialService.TAdd(_mapper.Map<Testimonial>(createTestimonialDto));
            return Ok("Müşteri Yorum Bilgisi Eklendi");
        }
        
         [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value  = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Müşteri Yorum Bilgisi Silindi");
        }
        
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TUpdate(_mapper.Map<Testimonial>(updateTestimonialDto));
            return Ok("Müşteri Yorum Bilgisi Güncellendi");
            
        }
        
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(_mapper.Map<GetTestimonialDto>(value));
        }
        
        
         
    }
    
    
    }

    
    
    