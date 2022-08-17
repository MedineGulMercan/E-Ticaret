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
    public class KategoriDal : GenericRepository<Kategori> , IKategoriDal
    {
        public KategoriDal(string tabloadi= "Kategori") : base(tabloadi)
        {

        }

    }
}
