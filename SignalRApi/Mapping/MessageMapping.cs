using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalR.DtoLayer.MessageDto;

namespace SignalRApi.Mapping;

public class MessageMapping : Profile
{
    public MessageMapping()
    {
        CreateMap<Message, ResultMessageDto>().ReverseMap();
        CreateMap<Message, CreateMessageDto>().ReverseMap();
        CreateMap<Message, UpdateMessageDto>().ReverseMap();
        CreateMap<Message, GetMessageDto>().ReverseMap();
        
    }
}