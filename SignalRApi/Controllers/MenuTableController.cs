using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

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

        // GET: api/MenuTable
        [HttpGet]
        public IActionResult MenuTableList()
        {
            var values = _menuTableService.TGetAll();
            return Ok(values);
        }

        // POST: api/MenuTable
        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            MenuTable menuTable = new MenuTable()
            {
                Name = createMenuTableDto.Name,
                Status = false
            };
            _menuTableService.TAdd(menuTable);
            return Ok("Masa başarılı bir şekilde eklendi.");
        }

        // DELETE: api/MenuTable/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            _menuTableService.TDelete(value);
            return Ok("Masa bilgisi silindi.");
        }

        // PUT: api/MenuTable
        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            MenuTable menuTable = new MenuTable()
            {
                MenuTableID = updateMenuTableDto.MenuTableID,
                Name = updateMenuTableDto.Name,
                Status = false
            };
            _menuTableService.TUpdate(menuTable);
            return Ok("Masa bilgisi güncellendi.");
        }

        // GET: api/MenuTable/{id}
        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            return Ok(value);
        }


        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            var count = _menuTableService.TMenuTableCount();
            return Ok(count);

        }
    
        
    }
}
      