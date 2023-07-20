using AutoMapper;
using RapidAPIConsume_DTOLayer.DTOs.RoomDto;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_PresentationLayer.Mapping
{
    public class AutoMappgerConfig : Profile
    {
        public AutoMappgerConfig()
        {
            CreateMap<AddRoomDto, Room>().ReverseMap();
            CreateMap<UpdateRoomDto, Room>().ReverseMap();
        }
    }
}
