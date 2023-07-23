
using System.ComponentModel.DataAnnotations;

namespace RapidAPIConsume_WEBUI.DTOs.BookingDtos
{
    public class AddBookingDto
    {
        [Required(ErrorMessage = "Lütfen bir isim girin")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen bir mail adresi girin")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir mail adresi girin")]
        public string Mail { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime CheckOut { get; set; }
        public string AdultCount { get; set; }
        public string ChildCount { get; set; }
        public string RoomCount { get; set; }
        public string SpecialRequest { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
