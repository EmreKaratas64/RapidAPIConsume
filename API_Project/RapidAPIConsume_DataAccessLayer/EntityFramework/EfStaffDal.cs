using RapidAPIConsume_DataAccessLayer.Abstract;
using RapidAPIConsume_DataAccessLayer.Concrete;
using RapidAPIConsume_DataAccessLayer.Repositories;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_DataAccessLayer.EntityFramework
{
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {
        public EfStaffDal(Context context) : base(context)
        {
        }

        public List<Staff> Last4Staffs()
        {
            var context = new Context();
            var values = context.Staffs.OrderByDescending(x => x.StaffID).Take(4).ToList();
            return values;
        }

        public int StaffCount()
        {
            var context = new Context();
            return context.Staffs.Count();
        }
    }
}
