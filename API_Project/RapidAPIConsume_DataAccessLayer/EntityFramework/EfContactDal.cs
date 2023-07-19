using RapidAPIConsume_DataAccessLayer.Concrete;
using RapidAPIConsume_DataAccessLayer.Repositories;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_DataAccessLayer.EntityFramework
{
    internal class EfContactDal : GenericRepository<Contact>
    {
        public EfContactDal(Context context) : base(context)
        {
        }
    }
}
