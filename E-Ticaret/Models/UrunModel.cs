using BL.Abstract;
using Dal.Concrete;
using Entities;

namespace E_Ticaret.Models
{
    
    public class UrunModel
    {
        
        UrunBL urunBL;
        KategoriBL kategoriBL;
        UrunDal urunDal;
        KategoriDal kategoriDal;
        MagazaDal magazaDal;
        public UrunModel()
        {
            urunBL = new UrunBL();  
            urunDal = new UrunDal();
            kategoriBL = new KategoriBL();
            kategoriDal = new KategoriDal();
            magazaDal = new MagazaDal();
        }

        public List<UrunDto> urunlerList = new List<UrunDto>();

        public void Getir(int id)
        {

            var urunler = urunBL.UrunGetirHepsi().Result.Where(x=>x.MagazaId==id);
            var kategori = kategoriBL.KategoriGetirHepsi().Result;
            var magaza = magazaDal.GetAllAsync().Result;

            foreach (var item in urunler)
            {
                UrunDto urunlerDto = new UrunDto()
                {
                    Id = item.Id,
                    UrunAd = item.UrunAd,
                    UrunFiyat = item.UrunFiyat, 
                    UrunOzellik = item.UrunOzellik,
                    UrunStok = item.UrunStok,   
                    
                    KategoriAd = kategori.FirstOrDefault(x=>x.Id == item.KategoriId).KategoriAd,

                    MagazaAd = magaza.FirstOrDefault(x=>x.Id == item.MagazaId).MagazaAd,
                    Aktifmi = item.Aktifmi,
                };
                urunlerList.Add(urunlerDto);
            }
        }

        public void GetirHepsi()
        {

            var urunler = urunBL.UrunGetirHepsi().Result;
            var kategori = kategoriBL.KategoriGetirHepsi().Result;
            var magaza = magazaDal.GetAllAsync().Result;

            foreach (var item in urunler)
            {
                UrunDto urunlerDto = new UrunDto()
                {
                    Id = item.Id,
                    UrunAd = item.UrunAd,
                    UrunFiyat = item.UrunFiyat,
                    UrunOzellik = item.UrunOzellik,
                    UrunStok = item.UrunStok,
                    KategoriAd = kategori.FirstOrDefault(x => x.Id == item.KategoriId).KategoriAd,
                    MagazaAd = magaza.FirstOrDefault(x => x.Id == item.MagazaId).MagazaAd,
                    Aktifmi = item.Aktifmi,
                };
                urunlerList.Add(urunlerDto);
            }
        }

        public List <KategoriModel> kategorilerList = new List<KategoriModel>();
        public void KategoriGetir()
        {
            var KategoriList = kategoriBL.KategoriGetirHepsi().Result;
            foreach (var item in KategoriList)
            {
                KategoriModel kategoriModel = new()
                {
                    Id = item.Id,
                    KategoriAd = item.KategoriAd,

                };
                kategorilerList.Add(kategoriModel);
            }
        }


        public void GuncelleGetir(int İd)
        {
            var urun = urunBL.UrunGetir(İd).Result;
            Id = urun.Id;
            MagazaId = urun.MagazaId;
            UrunAd = urun.UrunAd;
            KategoriId = urun.KategoriId;
            UrunOzellik = urun.UrunOzellik;
            UrunFiyat = urun.UrunFiyat;
            UrunStok = urun.UrunStok;
            Aktifmi = urun.Aktifmi;
        }



        public int Id { get; set; } 
        public int MagazaId { get; set; }
        public string? UrunAd { get; set; }
        public int KategoriId { get; set; }
        public string? UrunOzellik { get; set; }
        public decimal UrunFiyat { get; set; }
        public int UrunStok { get; set; }

        public bool? Aktifmi { get; set; }

    }
}
