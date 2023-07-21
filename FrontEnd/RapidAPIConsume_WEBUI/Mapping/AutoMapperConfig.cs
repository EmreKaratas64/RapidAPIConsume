using AutoMapper;
using RapidAPIConsume_DTOLayer.DTOs.RoomDto;
using RapidAPIConsume_EntityLayer.Concrete;
using RapidAPIConsume_WEBUI.DTOs.AccountDtos;
using RapidAPIConsume_WEBUI.DTOs.ServiceDtos;

namespace RapidAPIConsume_WEBUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AddRoomDto, Room>().ReverseMap();
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<AddServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<RegisterDto, AppUser>().ReverseMap();
            CreateMap<LoginDto, AppUser>().ReverseMap();
        }
    }
}
