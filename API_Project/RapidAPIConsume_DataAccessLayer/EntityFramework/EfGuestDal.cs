using RapidAPIConsume_DataAccessLayer.Abstract;
using RapidAPIConsume_DataAccessLayer.Concrete;
using RapidAPIConsume_DataAccessLayer.Repositories;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_DataAccessLayer.EntityFramework
{
    public class EfGuestDal : GenericRepository<Guest>, IGuestDal
    {
        public EfGuestDal(Context context) : base(context)
        {
        }

        public int GuestCount()
        {
            var context = new Context();
            return context.Guests.Count();
        }
    }
}
