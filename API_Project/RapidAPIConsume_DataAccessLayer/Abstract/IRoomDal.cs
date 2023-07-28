
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_DataAccessLayer.Abstract
{
    public interface IRoomDal : IGenericDal<Room>
    {
        int RoomCount();
    }
}
