using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalR.DtoLayer.NotificationDto;

namespace SignalRApi.Mapping;

public class NotificationMapping : Profile
{
    public NotificationMapping()
    {
        CreateMap<Notification, ResultNotificationDto>().ReverseMap();
        CreateMap<Notification, CreateNotificationDto>().ReverseMap();
        CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
        CreateMap<Notification, GetNotificationDto>().ReverseMap();
        
    }
}