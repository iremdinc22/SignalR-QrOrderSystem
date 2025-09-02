using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTableController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;

        public MenuTableController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            var count = _menuTableService.TMenuTableCount();
            return Ok(count);   

        }
        

        
    }
}
      