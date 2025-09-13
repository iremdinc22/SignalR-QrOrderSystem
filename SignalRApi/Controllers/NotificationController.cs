using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            return Ok(_notificationService.TGetAll());
        }

        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }


        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult GetAllNotificationByFalseList()
        {
            return Ok(_notificationService.TGetAllNotificationByFalse());
        }

        [HttpGet("{id}")]
        public IActionResult GetNotificationById(int id)
        {
            return Ok(_mapper.Map<GetNotificationDto>(_notificationService.TGetById(id)));
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var value =_mapper.Map<Notification>(createNotificationDto);
            _notificationService.TAdd(value);
            return Ok("Bildirim başarıyla eklendi.");


        }


        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var value = _mapper.Map<Notification>(updateNotificationDto);
            _notificationService.TUpdate(value);
            return Ok("Bildirim başarıyla güncellendi.");


        }


        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _notificationService.TGetById(id);
            _notificationService.TDelete(value);
            return Ok("Bildirim Kısmı Silindi.");
        }

        [HttpGet("NotificationStatusChangeToFalse/{id}")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
            _notificationService.TNotificationStatusChangeToFalse(id);
            return Ok("Güncelleme Yapıldı");
        }

        [HttpGet("NotificationStatusChangeToTrue/{id}")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            _notificationService.TNotificationStatusChangeToTrue(id);
            return Ok("Güncelleme Yapıldı");
        }




    }
}
