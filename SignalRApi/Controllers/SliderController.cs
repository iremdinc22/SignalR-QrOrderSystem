using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            _sliderService.TAdd(_mapper.Map<Slider>(createSliderDto));
            return Ok("Slider Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            _sliderService.TDelete(value);
            return Ok("Slider Silindi");
        }

        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            _sliderService.TUpdate(_mapper.Map<Slider>(updateSliderDto));
            return Ok("Slider Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            return Ok(_mapper.Map<ResultSliderDto>(value));
        }
    }
}
