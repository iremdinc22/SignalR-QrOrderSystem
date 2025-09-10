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

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetAll();
            return Ok(values);

        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            Message message = new Message()
            {
                NameSurname = createMessageDto.NameSurname,
                Mail = createMessageDto.Mail,
                Phone = createMessageDto.Phone,
                Subject = createMessageDto.Subject,
                MessageContent = createMessageDto.MessageContent,
                MessageSendDate = createMessageDto.MessageSendDate,
                Status = false
            };
            _messageService.TAdd(message);
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
            Message message = new Message()
            {
                MessageID = updateMessageDto.MessageID,
                NameSurname = updateMessageDto.NameSurname,
                Mail = updateMessageDto.Mail,
                Phone = updateMessageDto.Phone,
                Subject = updateMessageDto.Subject,
                MessageContent = updateMessageDto.MessageContent,
                MessageSendDate = updateMessageDto.MessageSendDate,
                Status = false
            };
            _messageService.TUpdate(message);
            return Ok("Mesajlar Kısmı Başarılı Bir Şekilde Güncelendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetById(id);
            return Ok(value);
            
        }



    }
}