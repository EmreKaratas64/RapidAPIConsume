using System.ComponentModel.DataAnnotations;

namespace RapidAPIConsume_DTOLayer.DTOs.RoomDto
{
    public class AddRoomDto
    {
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }
        [Required(ErrorMessage = "Please enter a price")]
        public int Price { get; set; }
        public string Title { get; set; }
        public string BedCount { get; set; }
        public string BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }
    }
}
