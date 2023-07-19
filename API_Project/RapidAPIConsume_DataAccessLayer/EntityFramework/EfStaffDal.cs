﻿using RapidAPIConsume_DataAccessLayer.Concrete;
using RapidAPIConsume_DataAccessLayer.Repositories;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_DataAccessLayer.EntityFramework
{
    public class EfStaffDal : GenericRepository<Staff>
    {
        public EfStaffDal(Context context) : base(context)
        {
        }
    }
}