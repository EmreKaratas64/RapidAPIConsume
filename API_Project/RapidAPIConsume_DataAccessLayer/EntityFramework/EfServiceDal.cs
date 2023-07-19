using RapidAPIConsume_DataAccessLayer.Concrete;
using RapidAPIConsume_DataAccessLayer.Repositories;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_DataAccessLayer.EntityFramework
{
    public class EfServiceDal : GenericRepository<Service>
    {
        public EfServiceDal(Context context) : base(context)
        {
        }
    }
}
