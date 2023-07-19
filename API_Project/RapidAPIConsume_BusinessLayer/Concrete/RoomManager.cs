using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_DataAccessLayer.Abstract;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_BusinessLayer.Concrete
{
    public class RoomManager : IRoomService
    {
        private readonly IRoomDal _roomDal;

        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        public void TDelete(Room entity)
        {
            throw new NotImplementedException();
        }

        public List<Room> TGetAll()
        {
            throw new NotImplementedException();
        }

        public Room TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TInsert(Room entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Room entity)
        {
            throw new NotImplementedException();
        }
    }
}
