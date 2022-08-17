namespace E_Ticaret.Models
{
    public class KullanicilarDto
    {

        public int Id { get; set; }
        public int YetkiId { get; set; }
        public string? YetkiAd { get; set; }

        public int MagazaId { get; set; }
        public string? MagazaAd { get; set; }
        public string? MagazaAdres { get; set; }
        public string? MagazaMail { get; set; }

        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? KullaniciAdi { get; set; }
        public string? Sifre { get; set; }
        public string? Mail { get; set; }
        public bool Aktifmi { get; set; }



    }
}
