using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult TotalOrderCount()
        {
            var count = _orderService.TTotalOrderCount();
            return Ok(count);

        }

        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {
            var count = _orderService.TActiveOrderCount();
            return Ok(count);

        }

        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            var price = _orderService.TLastOrderPrice();
            return Ok(price);       
        }
         
  }
}
