using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        
        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetAll());
            return Ok(values);
        }
        
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            var value = _mapper.Map<Contact>(createContactDto);
            _contactService.TAdd(value);
            return Ok("İletişim Bilgisi Eklendi");
            
        }
        
         [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value  = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("İletişim Bilgisi Silindi");
        }
        
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            _contactService.TUpdate(_mapper.Map<Contact>(updateContactDto));
            return Ok("İletişim Bilgisi Güncellendi");
            
        }
        
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(_mapper.Map<GetContactDto>(value));
        }
        
        


         
    }

    
    
    }
