using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_DataAccessLayer.Abstract;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_BusinessLayer.Concrete
{
    public class StaffManager : IStaffService
    {
        private readonly IStaffDal _staffDal;

        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public void TDelete(Staff entity)
        {
            _staffDal.Delete(entity);
        }

        public List<Staff> TGetAll()
        {
            return _staffDal.GetAll();
        }

        public Staff TGetById(int id)
        {
            return _staffDal.GetById(id);
        }

        public void TInsert(Staff entity)
        {
            _staffDal.Insert(entity);
        }

        public void TUpdate(Staff entity)
        {
            _staffDal.Update(entity);
        }
    }
}
