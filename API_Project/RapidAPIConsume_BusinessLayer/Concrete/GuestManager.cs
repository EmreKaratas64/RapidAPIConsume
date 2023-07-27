using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_DataAccessLayer.Abstract;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_BusinessLayer.Concrete
{
    public class GuestManager : IGuestService
    {
        private readonly IGuestDal _guestDal;

        public GuestManager(IGuestDal guestDal)
        {
            _guestDal = guestDal;
        }

        public void TDelete(Guest entity)
        {
            _guestDal.Delete(entity);
        }

        public List<Guest> TGetAll()
        {
            return _guestDal.GetAll();
        }

        public Guest TGetById(int id)
        {
            return _guestDal.GetById(id);
        }

        public int TGuestCount()
        {
            return _guestDal.GuestCount();
        }

        public void TInsert(Guest entity)
        {
            _guestDal.Insert(entity);
        }

        public void TUpdate(Guest entity)
        {
            _guestDal.Update(entity);
        }
    }
}
