﻿using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_DataAccessLayer.Abstract
{
    public interface IBookingDal : IGenericDal<Booking>
    {
        int BookingCount();

        List<Booking> Last6Bookings();
    }
}
