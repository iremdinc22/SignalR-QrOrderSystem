using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalR.DtoLayer.MenuTableDto;

namespace SignalRApi.Mapping;

public class MenuTableMapping : Profile
{
    public MenuTableMapping()
    {
        CreateMap<MenuTable, ResultMenuTableDto>().ReverseMap();
        CreateMap<MenuTable, CreateMenuTableDto>().ReverseMap();
        CreateMap<MenuTable, UpdateMenuTableDto>().ReverseMap();
        CreateMap<MenuTable, GetMenuTableDto>().ReverseMap();
        
    }
}