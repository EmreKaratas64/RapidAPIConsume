using RapidAPIConsume_DataAccessLayer.Concrete;
using RapidAPIConsume_DataAccessLayer.Repositories;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_DataAccessLayer.EntityFramework
{
    public class EfGuestDal : GenericRepository<Guest>
    {
        public EfGuestDal(Context context) : base(context)
        {
        }
    }
}
