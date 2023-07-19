using RapidAPIConsume_DataAccessLayer.Concrete;
using RapidAPIConsume_DataAccessLayer.Repositories;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_DataAccessLayer.EntityFramework
{
    public class EfSubscribeDal : GenericRepository<Subscribe>
    {
        public EfSubscribeDal(Context context) : base(context)
        {
        }
    }
}
