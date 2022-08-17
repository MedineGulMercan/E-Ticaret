using BL.Abstract;
using Dal.Concrete;
using E_Ticaret.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret.Controllers
{
    public class UrunController : Controller
    {
        UrunModel urunmodel;
        UrunBL urunBL;
        KullanicilarDal kullanicilarDal;
        public UrunController()
        {
            urunmodel = new UrunModel();
            urunBL = new UrunBL();
            kullanicilarDal = new();
        }

        public IActionResult Urun()
        {
            object isim = HttpContext.Session.GetString("_Name");
            int id = kullanicilarDal.GetAllAsync().Result.FirstOrDefault(x => x.KullaniciAdi == isim.ToString()).MagazaId;
            if (isim != null)
            {
                urunmodel.Getir(id);
                urunmodel.KategoriGetir();
                return View(urunmodel);

            }
            return RedirectToAction("Login", "Login");


        }

        [HttpPost]
        public async Task<IActionResult> UrunEkle(UrunModel urunModel)
        {
            object isim = HttpContext.Session.GetString("_Name");
            int id = kullanicilarDal.GetAllAsync().Result.FirstOrDefault(x => x.KullaniciAdi == isim.ToString()).MagazaId;

            Urun urun = new()
            {
                MagazaId = id,
                UrunAd = urunModel.UrunAd,
                KategoriId = urunModel.KategoriId,
                UrunOzellik = urunModel.UrunOzellik,
                UrunFiyat = urunModel.UrunFiyat,
                UrunStok = urunModel.UrunStok,
                Aktifmi = true,
            };
            await urunBL.UrunEkle(urun);
            return RedirectToAction("Urun");
        }


        [HttpPost]
        public async Task<IActionResult> UrunSil(int Id)
        {
            await urunBL.UrunSil(Id);
            return RedirectToAction("Urun");
        }

        [HttpGet]
        public async Task<IActionResult> UrunGuncelle(int Id)
        {
            object isim = HttpContext.Session.GetString("_Name");
            if (isim != null)
            {
                urunmodel.GuncelleGetir(Id);
                urunmodel.KategoriGetir();
                return View(urunmodel);
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public async Task<IActionResult> UrunGuncelle(UrunModel urunModel)
        {
            object isim = HttpContext.Session.GetString("_Name");
            if (isim != null)
            {
                Urun urun = new()
                {
                    Id = urunModel.Id,
                    UrunAd = urunModel.UrunAd,
                    KategoriId = urunModel.KategoriId,
                    UrunOzellik = urunModel.UrunOzellik,
                    UrunFiyat = urunModel.UrunFiyat,
                    UrunStok = urunModel.UrunStok,
                };
                await urunBL.UrunGuncelle(urun);

                return RedirectToAction("Urun");
            }
            return RedirectToAction("Login", "Login");
        }

        public int Id { get; set; }
        public int MagazaId { get; set; }
        public string? UrunAd { get; set; }
        public int KategoriId { get; set; }
        public string? UrunOzellik { get; set; }
        public decimal UrunFiyat { get; set; }
        public int UrunStok { get; set; }


    }
}
