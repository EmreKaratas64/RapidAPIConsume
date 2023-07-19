using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_DataAccessLayer.Abstract;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_BusinessLayer.Concrete
{
    public class SubscribeManager : ISubscribeService
    {
        private readonly ISubscribeDal _subscribeDal;

        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }

        public void TDelete(Subscribe entity)
        {
            throw new NotImplementedException();
        }

        public List<Subscribe> TGetAll()
        {
            throw new NotImplementedException();
        }

        public Subscribe TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TInsert(Subscribe entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Subscribe entity)
        {
            throw new NotImplementedException();
        }
    }
}
