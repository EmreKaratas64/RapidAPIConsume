﻿namespace RapidAPIConsume_EntityLayer.Concrete
{
    public class Booking
    {
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime CheckOut { get; set; }
        public string AdultCount { get; set; }
        public string ChildCount { get; set; }
        public string RoomCount { get; set; }
        public string? SpecialRequest { get; set; }
        public string? Description { get; set; }
        public BookingStatus Status { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }

    public enum BookingStatus
    {
        Bekleniyor = 0,
        Onaylandı = 1,
        IptalEdildi = 2
    }
}
