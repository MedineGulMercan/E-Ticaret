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
    public class KullanicilarDal : GenericRepository<Kullanicilar> , IKullanicilarDal
    {
        public KullanicilarDal(string tabloadi = "Kullanicilar") : base(tabloadi)
        {

        }

    }
}
