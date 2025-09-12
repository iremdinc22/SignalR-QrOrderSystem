using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetAll();
            return Ok(values);

        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
                Name = createBookingDto.Name,
                Phone = createBookingDto.Phone,
                Mail = createBookingDto.Mail,
                PersonCount = createBookingDto.PersonCount,
                Date = DateTime.SpecifyKind(createBookingDto.Date, DateTimeKind.Utc),
                Description = createBookingDto.Description

            };
            _bookingService.TAdd(booking);
            return Ok("Rezervasyon Yapıldı.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Rezervasyon Silindi.");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                BookingID = updateBookingDto.BookingID,
                Name = updateBookingDto.Name,
                Phone = updateBookingDto.Phone,
                Mail = updateBookingDto.Mail,
                PersonCount = updateBookingDto.PersonCount,
                Date = DateTime.SpecifyKind(updateBookingDto.Date, DateTimeKind.Utc),
                Description = updateBookingDto.Description

            };
            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon Güncelendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);

        }

        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.TBookingStatusApproved(id);
            return Ok("Rezervasyon Açıklaması Değiştirildi.");

        }

        [HttpGet("BookingStatusCancelled/{id}")]
        public IActionResult BookingStatusCancelled(int id)
        {
            _bookingService.TBookingStatusCancelled(id);
            return Ok("Rezervasyon Açıklaması Değiştirildi.");

        }

        [HttpGet("GetActiveBookingCount")]
        public IActionResult GetActiveBookingCount()
        {
            var count = _bookingService.TGetActiveBookingCount();
            return Ok(count);

        }

        [HttpGet("GetPassiveBookingCount")]
        public IActionResult GetPassiveBookingCount()
        {
            var count = _bookingService.TGetPassiveBookingCount();
            return Ok(count);

        }

        [HttpGet("GetTotalBookingCount")]
        public IActionResult GetTotalBookingCount()
        {
            var count = _bookingService.TGetTotalBookingCount();
            return Ok(count);       
        }
        
        
    }
}