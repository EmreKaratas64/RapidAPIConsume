using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_BusinessLayer.Abstract
{
    public interface IStaffService : IGenericService<Staff>
    {
        int TStaffCount();

        List<Staff> TLast4Staffs();
    }
}
