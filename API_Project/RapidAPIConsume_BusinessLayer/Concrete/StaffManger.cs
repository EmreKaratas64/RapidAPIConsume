using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_DataAccessLayer.Abstract;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_BusinessLayer.Concrete
{
    public class StaffManger : IStaffService
    {
        private readonly IStaffDal _staffDal;

        public StaffManger(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public void TDelete(Staff entity)
        {
            throw new NotImplementedException();
        }

        public List<Staff> TGetAll()
        {
            throw new NotImplementedException();
        }

        public Staff TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TInsert(Staff entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Staff entity)
        {
            throw new NotImplementedException();
        }
    }
}
