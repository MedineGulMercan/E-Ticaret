namespace E_Ticaret.Models
{
    public class UrunDto
    {
        public int Id { get; set; }
        public int MagazaId { get; set; }
        public string MagazaAd { get; set; }
        public string? UrunAd { get; set; }
       
        public string? UrunOzellik { get; set; }
        public decimal UrunFiyat { get; set; }
        public int UrunStok { get; set; }
        public int KategoriId { get; set; }
        public string? KategoriAd { get; set; }
        public bool? Aktifmi { get; set; }


    }
}
