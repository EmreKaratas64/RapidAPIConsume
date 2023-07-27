

using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_DataAccessLayer.Abstract
{
    public interface IGuestDal : IGenericDal<Guest>
    {
        int GuestCount();
    }
}
