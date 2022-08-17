using BL.Abstract;
using E_Ticaret.Models;
using Microsoft.AspNetCore.Mvc;
using Entities;

namespace E_Ticaret.Controllers
{
    public class KullanicilarController : Controller
    {
        KullanicilarModel kullanicilarModel;
        KullanicilarBL kullanicilarBL;

        public KullanicilarController()
        {
            kullanicilarBL = new KullanicilarBL();
            kullanicilarModel = new KullanicilarModel();
        }
        public IActionResult Kullanicilar()
        {
            object isim = HttpContext.Session.GetString("_Name");
            if (isim!=null)
            {
                kullanicilarModel.Getir();
                kullanicilarModel.YetkiGetir();
                kullanicilarModel.MagazaGetir();
                return View(kullanicilarModel);
                
            }
            return RedirectToAction("Login","Login");
            
        }
        
        [HttpPost]
        public async Task<IActionResult> KullanicilarEkle(KullanicilarModel kullanicilarModel)
        {
            Kullanicilar kullanicilar = new()
            {
                Id = kullanicilarModel.Id,
                Ad = kullanicilarModel.Ad,
                Soyad = kullanicilarModel.Soyad,
                KullaniciAdi = kullanicilarModel.KullaniciAdi,
                Sifre = kullanicilarModel.Sifre,
                Mail = kullanicilarModel.Mail,
                YetkiId = kullanicilarModel.YetkiId,
                MagazaId = kullanicilarModel.MagazaId,
            };
            if (kullanicilarModel.YetkiId == 0 && kullanicilarModel.MagazaId == 0)
            {
                await kullanicilarBL.KullanicilarEkleBL(kullanicilar);
                return RedirectToAction("Login", "Login");
            }
            else
            {
                await kullanicilarBL.KullanicilarEkleBL(kullanicilar);
                return RedirectToAction("Kullanicilar", "Kullanicilar");
            }
        }

        [HttpPost]
        public async Task<IActionResult> KullanicilarSil(int id)
        {
            await kullanicilarBL.KullanicilarSilBL(id);
            return RedirectToAction("Kullanicilar");
        }

        [HttpGet]
        public async Task<IActionResult> KullanicilarGuncelle(int Id)
        {
            kullanicilarModel.GuncelleGetir(Id);
            kullanicilarModel.MagazaGetir();
            kullanicilarModel.YetkiGetir();
            return View(kullanicilarModel);

        }

        [HttpPost]
        public async Task<IActionResult> KullanicilarGuncelle(KullanicilarModel kullanicilarModel)
        {
            Kullanicilar kullanicilar = new()
            {
                Id = kullanicilarModel.Id,      
                Ad = kullanicilarModel.Ad,
                Soyad = kullanicilarModel.Soyad,
                Sifre = kullanicilarModel.Sifre,
                Mail = kullanicilarModel.Mail,
                YetkiId = kullanicilarModel.YetkiId,
                MagazaId = kullanicilarModel.MagazaId,
                Aktifmi = true,

            };
            await kullanicilarBL.KullanicilarGuncelleBL(kullanicilar);
            return RedirectToAction("Kullanicilar");
            
        }
    }
}
