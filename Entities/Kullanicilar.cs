using Core.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Kullanicilar:BaseEntity
    {
        public string? Ad { get; set; } 
        public string? Soyad { get; set; } 
        public string? KullaniciAdi { get; set; } 
        public string? Sifre { get; set; } 
        public string? Mail { get; set; } 
        public int YetkiId { get; set; } 
        public int MagazaId { get; set; } 
        public bool Aktifmi { get; set; } 
    }
}
