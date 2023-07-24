using AutoMapper;
using RapidAPIConsume_DTOLayer.DTOs.RoomDto;
using RapidAPIConsume_EntityLayer.Concrete;
using RapidAPIConsume_WEBUI.DTOs.AboutDtos;
using RapidAPIConsume_WEBUI.DTOs.AccountDtos;
using RapidAPIConsume_WEBUI.DTOs.BookingDtos;
using RapidAPIConsume_WEBUI.DTOs.GuestDtos;
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
            CreateMap<AddBookingDto, Booking>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();
            CreateMap<UpdateRoomDto, Room>().ReverseMap();
            CreateMap<AddGuestDto, Guest>().ReverseMap();
            CreateMap<UpdateGuestDto, Guest>().ReverseMap();
        }
    }
}
