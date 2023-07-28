
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_DataAccessLayer.Abstract
{
    public interface IStaffDal : IGenericDal<Staff>
    {
        int StaffCount();
    }
}
