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
            _roomDal.Delete(entity);
        }

        public List<Room> TGetAll()
        {
            return _roomDal.GetAll();
        }

        public Room TGetById(int id)
        {
            return _roomDal.GetById(id);
        }

        public void TInsert(Room entity)
        {
            _roomDal.Insert(entity);
        }

        public int TRoomCount()
        {
            return _roomDal.RoomCount();
        }

        public void TUpdate(Room entity)
        {
            _roomDal.Update(entity);
        }
    }
}
