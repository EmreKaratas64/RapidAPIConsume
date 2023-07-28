

using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_BusinessLayer.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
        int TBookingCount();

        List<Booking> TLast6Bookings();
    }
}
