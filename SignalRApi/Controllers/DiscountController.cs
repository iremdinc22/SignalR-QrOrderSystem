using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            _discountService.TAdd(_mapper.Map<Discount>(createDiscountDto));
            return Ok("İndirim Kuponu Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("İndirim Kuponu Silindi");
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            _discountService.TUpdate( _mapper.Map<Discount>(updateDiscountDto));
            return Ok("İndirim Kuponu Güncellendi");

        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            return Ok(_mapper.Map<GetDiscountDto>(value));
        }

        [HttpPut("ChangeStatusToTrue/{id}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _discountService.TChangeStatusToTrue(id);
            return Ok("İndirim Kuponu Aktif Edildi");
        }

        [HttpPut("ChangeStatusToFalse/{id}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _discountService.TChangeStatusToFalse(id);
            return Ok("İndirim Kuponu Pasif Edildi");

        } 
        
        [HttpGet("GetActiveDiscounts")]
        public IActionResult GetActiveDiscounts()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetActiveDiscounts());
            return Ok(values);
        }

    
     }
    }
