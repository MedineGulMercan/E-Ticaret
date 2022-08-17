using Dal.Concrete;
using Dapper;

namespace E_Ticaret.Models
{
    public class KullanicilarModel
    {
        KullanicilarDal kullanicilarDal;
        YetkiDal yetkiDal;
        MagazaDal magazaDal;

        public KullanicilarModel()
        {
            kullanicilarDal = new KullanicilarDal();
            yetkiDal = new YetkiDal();
            magazaDal = new MagazaDal();
            
        }
        public List<KullanicilarDto> kullanicilarList = new List<KullanicilarDto>();
        public void Getir()
        {
            var kullanicilar = kullanicilarDal.GetAllAsync().Result;
            var magazalar = magazaDal.GetAllAsync().Result;
            var yetkiler = yetkiDal.GetAllAsync().Result;
            foreach (var item in kullanicilar)
            {
                KullanicilarDto kullanicilarDto = new KullanicilarDto()
                {
                    Id = item.Id,
                    Ad = item.Ad,
                    Soyad = item.Soyad,
                    KullaniciAdi = item.KullaniciAdi,
                    Sifre = item.Sifre,
                    Mail = item.Mail,

                    YetkiId = item.YetkiId,
                    MagazaId = item.MagazaId,
                    Aktifmi = item.Aktifmi,

                    MagazaAd = magazalar.FirstOrDefault(x=> x.Id == item.MagazaId).MagazaAd,
                    MagazaAdres = magazalar.FirstOrDefault(x=> x.Id == item.MagazaId).MagazaAdres,
                    MagazaMail = magazalar.FirstOrDefault(x=>x.Id == item.MagazaId).MagazaMail,

                    YetkiAd = yetkiler.FirstOrDefault(x=>x.Id == item.YetkiId).YetkiAd,
                };
                kullanicilarList.Add(kullanicilarDto);            }
        }
        public List<YetkiModel> YetkilerList = new List<YetkiModel>();
        public void YetkiGetir()
        {
            var yetkiList = yetkiDal.GetAllAsync().Result;
            foreach (var item in yetkiList)
            {

                YetkiModel yetkiModel = new YetkiModel()
                {
                    Id = item.Id,
                    YetkiAd = item.YetkiAd
                };
                YetkilerList.Add(yetkiModel);
            }
        }
        public List<MagazaModel> MagazalarList = new List<MagazaModel>();
        public void MagazaGetir()
        {
            var magazaList = magazaDal.GetAllAsync().Result;
            foreach (var item in magazaList)
            {
                MagazaModel magazaModel = new MagazaModel()
                { 
                    Id = item.Id,
                    MagazaAd = item.MagazaAd,
                };
                MagazalarList.Add(magazaModel);
            }
        }
        public void GuncelleGetir(int id)
        {
            var kullanicilar = kullanicilarDal.GetAsync(id).Result;
            Id = kullanicilar.Id;
            Ad = kullanicilar.Ad;
            Soyad = kullanicilar.Soyad;
            KullaniciAdi = kullanicilar.KullaniciAdi;
            Sifre = kullanicilar.Sifre;
            Mail = kullanicilar.Mail;
            YetkiId = kullanicilar.YetkiId;
            MagazaId = kullanicilar.MagazaId;
        }
        public int Id { get; set; }
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
