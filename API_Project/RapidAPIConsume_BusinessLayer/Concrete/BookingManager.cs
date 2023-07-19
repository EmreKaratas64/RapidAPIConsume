using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_DataAccessLayer.Abstract;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void TDelete(Booking entity)
        {
            throw new NotImplementedException();
        }

        public List<Booking> TGetAll()
        {
            throw new NotImplementedException();
        }

        public Booking TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TInsert(Booking entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Booking entity)
        {
            throw new NotImplementedException();
        }
    }
}
