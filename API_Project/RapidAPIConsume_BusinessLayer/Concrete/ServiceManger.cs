using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_DataAccessLayer.Abstract;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_BusinessLayer.Concrete
{
    public class ServiceManger : IServiceService
    {
        private readonly IServiceDal _serviceDal;

        public ServiceManger(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void TDelete(Service entity)
        {
            throw new NotImplementedException();
        }

        public List<Service> TGetAll()
        {
            throw new NotImplementedException();
        }

        public Service TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TInsert(Service entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Service entity)
        {
            throw new NotImplementedException();
        }
    }
}
