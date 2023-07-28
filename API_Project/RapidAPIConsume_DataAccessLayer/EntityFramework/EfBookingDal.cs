

using RapidAPIConsume_DataAccessLayer.Abstract;
using RapidAPIConsume_DataAccessLayer.Concrete;
using RapidAPIConsume_DataAccessLayer.Repositories;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {
        }

        public int BookingCount()
        {
            var context = new Context();
            return context.Bookings.Count();
        }

        public List<Booking> Last6Bookings()
        {
            var context = new Context();
            var values = context.Bookings.OrderByDescending(x => x.BookingID).Take(6).ToList();
            return values;
        }
    }
}
