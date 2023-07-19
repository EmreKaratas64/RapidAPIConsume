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
            throw new NotImplementedException();
        }

        public List<Guest> TGetAll()
        {
            throw new NotImplementedException();
        }

        public Guest TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TInsert(Guest entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Guest entity)
        {
            throw new NotImplementedException();
        }
    }
}
