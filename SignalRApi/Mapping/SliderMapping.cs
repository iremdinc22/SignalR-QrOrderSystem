using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalR.DtoLayer.SliderDto;

namespace SignalRApi.Mapping;

public class SliderMapping : Profile
{
    public SliderMapping()
    {
        CreateMap<Slider, ResultSliderDto>().ReverseMap();
        CreateMap<Slider, CreateSliderDto>().ReverseMap();
        CreateMap<Slider, UpdateSliderDto>().ReverseMap();
        CreateMap<Slider, GetSliderDto>().ReverseMap();
        
    }
}