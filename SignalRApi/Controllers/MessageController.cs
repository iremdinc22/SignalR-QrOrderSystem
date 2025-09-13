using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _mapper.Map<List<ResultMessageDto>>(_messageService.TGetAll());
            return Ok(values);

        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            var entity = _mapper.Map<Message>(createMessageDto);

            // kritik satır: tarihi biz veriyoruz
            entity.MessageSendDate = DateTime.UtcNow; // veya DateTime.Now (lokale göre)

            // istersen varsayılan durum da ver:
            if (entity.Status == default) entity.Status = false;

            _messageService.TAdd(entity);
            return Ok("Mesaj Başarılı Bir Şekilde Gönderildi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetById(id);
            _messageService.TDelete(value);
            return Ok("Mesaj Silindi.");

        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateMessageDto updateMessageDto)
        {
            var value = _mapper.Map<Message>(updateMessageDto);
            _messageService.TUpdate(value);
            return Ok("Mesajlar Kısmı Başarılı Bir Şekilde Güncelendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetById(id);
            return Ok(_mapper.Map<GetMessageDto>(value));

        }



    }
}