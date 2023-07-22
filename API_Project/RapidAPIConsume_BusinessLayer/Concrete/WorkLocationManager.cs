using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_DataAccessLayer.Abstract;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_BusinessLayer.Concrete
{
    public class WorkLocationManager : IWorkLocationService
    {
        private readonly IWorkLocationDal _workLocationDal;

        public WorkLocationManager(IWorkLocationDal workLocationDal)
        {
            _workLocationDal = workLocationDal;
        }

        public void TDelete(WorkLocation entity)
        {
            throw new NotImplementedException();
        }

        public List<WorkLocation> TGetAll()
        {
            return _workLocationDal.GetAll();
        }

        public WorkLocation TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TInsert(WorkLocation entity)
        {
            _workLocationDal.Insert(entity);
        }

        public void TUpdate(WorkLocation entity)
        {
            _workLocationDal.Update(entity);
        }
    }
}
