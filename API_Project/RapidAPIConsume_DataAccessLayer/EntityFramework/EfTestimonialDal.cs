using RapidAPIConsume_DataAccessLayer.Concrete;
using RapidAPIConsume_DataAccessLayer.Repositories;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_DataAccessLayer.EntityFramework
{
    public class EfTestimonialDal : GenericRepository<Testimonial>
    {
        public EfTestimonialDal(Context context) : base(context)
        {
        }
    }
}
