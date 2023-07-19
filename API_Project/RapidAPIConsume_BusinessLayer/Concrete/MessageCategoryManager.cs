using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_DataAccessLayer.Abstract;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_BusinessLayer.Concrete
{
    public class MessageCategoryManager : IMessageCategoryService
    {
        private readonly IMessageCategoryDal _messageCategoryDal;

        public MessageCategoryManager(IMessageCategoryDal messageCategoryDal)
        {
            _messageCategoryDal = messageCategoryDal;
        }

        public void TDelete(MessageCategory entity)
        {
            throw new NotImplementedException();
        }

        public List<MessageCategory> TGetAll()
        {
            throw new NotImplementedException();
        }

        public MessageCategory TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TInsert(MessageCategory entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(MessageCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
