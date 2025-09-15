using AutoMapper;
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
        private readonly IMapper _mapper;

        public MenuTableController(IMenuTableService menuTableService, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
        }

        // GET: api/MenuTable
        [HttpGet]
        public IActionResult MenuTableList()
        {
            var values = _mapper.Map<List<ResultMenuTableDto>>(_menuTableService.TGetAll());
            return Ok(values);
        }

        // POST: api/MenuTable
        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            _menuTableService.TAdd(_mapper.Map<MenuTable>(createMenuTableDto));
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
            var value = _mapper.Map<MenuTable>(updateMenuTableDto);
            _menuTableService.TUpdate(value);
            return Ok("Masa bilgisi güncellendi.");
        }

        // GET: api/MenuTable/{id}
        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            return Ok(_mapper.Map<GetMenuTableDto>(value));
        }


        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            var count = _menuTableService.TMenuTableCount();
            return Ok(count);

        }

        [HttpPut("ChangeMenuTableStatus/{id}")]
        public IActionResult ChangeMenuTableStatus(int id, [FromQuery] bool status)
        {
            _menuTableService.TChangeMenuTableStatus(id, status);
            return Ok("Masa durumu güncellendi.");

        }
    }
}
      