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
            throw new NotImplementedException();
        }

        public WorkLocation TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TInsert(WorkLocation entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(WorkLocation entity)
        {
            throw new NotImplementedException();
        }
    }
}
