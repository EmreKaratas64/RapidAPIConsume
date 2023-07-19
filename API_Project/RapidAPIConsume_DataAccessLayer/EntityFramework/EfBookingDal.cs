

using RapidAPIConsume_DataAccessLayer.Concrete;
using RapidAPIConsume_DataAccessLayer.Repositories;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>
    {
        public EfBookingDal(Context context) : base(context)
        {
        }
    }
}
