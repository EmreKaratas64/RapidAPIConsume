using RapidAPIConsume_DataAccessLayer.Abstract;
using RapidAPIConsume_DataAccessLayer.Concrete;
using RapidAPIConsume_DataAccessLayer.Repositories;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_DataAccessLayer.EntityFramework
{
    public class EfWorkLocationDal : GenericRepository<WorkLocation>, IWorkLocationDal
    {
        public EfWorkLocationDal(Context context) : base(context)
        {
        }
    }
}
