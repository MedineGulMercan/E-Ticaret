using Core.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Urun : BaseEntity
    {
       
        public int MagazaId { get; set; }
        public string? UrunAd { get; set; }
        public int KategoriId { get; set; }
        public string? UrunOzellik { get; set; }
        public decimal UrunFiyat { get; set; }
        public int UrunStok { get; set; }
        public bool? Aktifmi { get; set; }
    }
}
