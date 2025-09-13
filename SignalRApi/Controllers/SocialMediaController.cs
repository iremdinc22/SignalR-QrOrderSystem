using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;
        
        public  SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetAll());
            return Ok(values);
        }
        
        [HttpPost]
        public IActionResult CreateProduct(CreateSocialMediaDto createSocialMediaDto)
        {
            _socialMediaService.TAdd(_mapper.Map<SocialMedia>(createSocialMediaDto));
            return Ok("Sosyal Medya Bilgisi Eklendi");
        }
        
         [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value  = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(value);
            return Ok("Sosyal Medya Bilgisi Silindi");
        }
        
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            _socialMediaService.TUpdate(_mapper.Map<SocialMedia>(updateSocialMediaDto));
            return Ok("Sosyal Medya Bilgisi Güncellendi");
            
        }
        
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            return Ok(_mapper.Map<GetSocialMediaDto>(value));
        }
        
        
        
        
        
        
            
            
            
        

         
    }

    
    
    }