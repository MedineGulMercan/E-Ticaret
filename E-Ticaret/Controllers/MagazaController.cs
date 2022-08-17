using BL.Abstract;
using Dal.Concrete;
using E_Ticaret.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret.Controllers
{
    public class MagazaController : Controller
    {
        KullanicilarBL kullanicilarBL;
        MagazaDal magazaDal;
        public MagazaController()
        {
            kullanicilarBL = new KullanicilarBL();
            magazaDal = new MagazaDal();    
        }
        public IActionResult Magaza()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> MagazaEkle(KullanicilarDto kullanicilarDto)
        {
            Magaza magaza = new()
            {
                MagazaAd=kullanicilarDto.MagazaAd,
                MagazaAdres = kullanicilarDto.MagazaAdres,
                MagazaMail = kullanicilarDto.MagazaMail,
            };
            await magazaDal.CreateAsync(magaza);

            Kullanicilar kullanicilar = new()
            {
                Ad=kullanicilarDto.Ad,
                Soyad=kullanicilarDto.Soyad,
                Sifre=kullanicilarDto.Sifre,
                Mail=kullanicilarDto.Mail,
                KullaniciAdi = kullanicilarDto.KullaniciAdi + kullanicilarDto.Soyad,
                YetkiId = 2,
                MagazaId = magazaDal.GetAllAsync().Result.OrderByDescending(x => x.Id).First().Id,
                
            };
            await kullanicilarBL.KullanicilarEkleBL(kullanicilar);
            return RedirectToAction("Login", "Login");
        }



    }
}
