using Core.Concrete;
using Dal.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Concrete
{
    public class YetkiDal : GenericRepository<Yetki> , IYetkiDal
    {
        public YetkiDal(string tabloadi = "Yetki") : base(tabloadi)
        {

        }
    }
}
