using Core.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Sepet : BaseEntity
    {
        public int KullaniciId { get; set; } 
        public decimal KullaniciFiyat { get; set; } 
        public int UrunId { get; set; } 
        public int UrunAdet { get; set; } 
    }
}
