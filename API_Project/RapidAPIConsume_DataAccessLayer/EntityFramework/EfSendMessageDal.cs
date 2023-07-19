using RapidAPIConsume_DataAccessLayer.Concrete;
using RapidAPIConsume_DataAccessLayer.Repositories;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_DataAccessLayer.EntityFramework
{
    public class EfSendMessageDal : GenericRepository<SendMessage>
    {
        public EfSendMessageDal(Context context) : base(context)
        {
        }
    }
}
