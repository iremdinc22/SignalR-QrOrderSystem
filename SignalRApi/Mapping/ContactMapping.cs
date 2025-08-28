using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalR.DtoLayer.ContactDto;

namespace SignalRApi.Mapping;

public class ContactMapping : Profile
{
    public ContactMapping()
    {
        CreateMap<Contact, ResultContactDto>().ReverseMap();
        CreateMap<Contact, CreateContactDto>().ReverseMap();
        CreateMap<Contact, UpdateContactDto>().ReverseMap();
        CreateMap<Contact, GetContactDto>().ReverseMap();
        
      
    }
}