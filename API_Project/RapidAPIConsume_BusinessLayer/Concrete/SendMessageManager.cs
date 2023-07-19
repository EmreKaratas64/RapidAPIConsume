using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_DataAccessLayer.Abstract;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_BusinessLayer.Concrete
{
    public class SendMessageManager : ISendMessageService
    {
        private readonly ISendMessageDal _sendMessageDal;

        public SendMessageManager(ISendMessageDal sendMessageDal)
        {
            _sendMessageDal = sendMessageDal;
        }

        public void TDelete(SendMessage entity)
        {
            throw new NotImplementedException();
        }

        public List<SendMessage> TGetAll()
        {
            throw new NotImplementedException();
        }

        public SendMessage TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TInsert(SendMessage entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(SendMessage entity)
        {
            throw new NotImplementedException();
        }
    }
}
