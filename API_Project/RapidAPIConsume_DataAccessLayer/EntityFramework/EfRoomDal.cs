using RapidAPIConsume_DataAccessLayer.Concrete;
using RapidAPIConsume_DataAccessLayer.Repositories;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_DataAccessLayer.EntityFramework
{
    public class EfRoomDal : GenericRepository<Room>
    {
        public EfRoomDal(Context context) : base(context)
        {
        }
    }
}
