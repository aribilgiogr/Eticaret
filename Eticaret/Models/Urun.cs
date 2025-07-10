namespace Eticaret.Models
{
    public class Urun
    {
        //(urunid, ad, fiyati, marka, model)
        public int UrunId { get; set; }
        public string UrunAd { get; set; }
        public double UrunFiyati { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string FotoPath { get; set; }
        public Kategori Category { get; set; }
        //Foreign key
        public int KategoriId { get; set; }
    }
}
