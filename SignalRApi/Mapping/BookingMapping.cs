using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalR.DtoLayer.BookingDto;

namespace SignalRApi.Mapping;

public class BookingMapping : Profile
{
    public BookingMapping()
    {
        CreateMap<Booking, ResultBookingDto>().ReverseMap();
        CreateMap<Booking, CreateBookingDto>().ReverseMap();
        CreateMap<Booking, UpdateBookingDto>().ReverseMap();
        CreateMap<Booking, GetBookingDto>().ReverseMap();
        
    }
}